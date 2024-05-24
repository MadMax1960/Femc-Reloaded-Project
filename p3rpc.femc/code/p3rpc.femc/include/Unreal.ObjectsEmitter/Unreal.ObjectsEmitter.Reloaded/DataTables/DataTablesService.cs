using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using System.Diagnostics.CodeAnalysis;
using Unreal.ObjectsEmitter.Interfaces;
using Unreal.ObjectsEmitter.Interfaces.Types;
using Unreal.ObjectsEmitter.Reloaded.Unreal;

namespace Unreal.ObjectsEmitter.Reloaded.DataTables;

internal unsafe class DataTablesService : IDataTables
{
    private record TableListener(string TableName, Action<DataTable> Callback);

    [Function(CallingConventions.Microsoft)]
    private delegate nint FUN_142f283d0(UDataTable* tableObj, nint param2);
    private IHook<FUN_142f283d0>? dtFunctionHook;

    private readonly UnrealService unreal;
    private readonly Dictionary<string, DataTable> dataTables = new();
    private readonly List<TableListener> tableListeners = new();
    private bool logTables;

    public DataTablesService(UnrealService unreal)
    {
        this.unreal = unreal;

        ScanHooks.Add(
            nameof(FUN_142f283d0),
            "48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B 02 48 8B DA 48 8B F9 48 8B 70 ?? E8",
            (hooks, result) => this.dtFunctionHook = hooks.CreateHook<FUN_142f283d0>(this.DtFunction, result).Activate());

        this.DataTableFound += (table) =>
        {
            foreach (var listener in this.tableListeners)
            {
                if (listener.TableName == table.Name)
                {
                    listener.Callback(table);
                }
            }
        };
    }

    public void SetLogTables(bool logTables) => this.logTables = logTables;

    public void FindDataTable(string tableName, Action<DataTable> found)
        => this.tableListeners.Add(new(tableName, found));

    public Action<DataTable>? DataTableFound { get; set; }

    public bool TryGetDataTable(string tableName, [NotNullWhen(true)] out DataTable? dataTable)
        => this.dataTables.TryGetValue(tableName, out dataTable);

    public DataTable[] GetDataTables()
        => this.dataTables.Values.ToArray();

    private nint DtFunction(UDataTable* tableObj, nint param2)
    {
        var result = this.dtFunctionHook!.OriginalFunction(tableObj, param2);
        var tableName = this.unreal.GetName(tableObj->BaseObj.NamePrivate);
        var structName = this.unreal.GetName(tableObj->RowStruct->baseObj.NamePrivate);

        this.LogTable($"{tableName} || {structName} || {(nint)tableObj:X}");

        var rows = new List<Row>();
        for (int i = 0, j = 0; i < tableObj->RowMap.MapNum; i++, j++)
        {
            var row = tableObj->RowMap.Elements[i];
            var rowName = this.unreal.GetName((uint)row.Key);
            var rowPtr = row.Value;

            rows.Add(new(rowName, (UObject*)rowPtr));
            if (j < 5)
            {
                this.LogTable($"\t{rowName}: {rowPtr:X}");
            }
            else if (j == 5)
            {
                this.LogTable($"\t...with {tableObj->RowMap.MapNum - j} more.");
            }
        }

        var dataTable = new DataTable(tableName, tableObj, rows.ToArray());
        if (!this.dataTables.ContainsKey(tableName))
        {
            this.dataTables[tableName] = dataTable;
        }
        else
        {
            this.LogTable($"Loaded a table with a duplicate name, overwriting: {tableName}");
            this.dataTables[tableName] = dataTable;
        }

        this.DataTableFound?.Invoke(dataTable);
        return result;
    }

    private void LogTable(string message)
    {
        if (this.logTables)
        {
            Log.Information(message);
        }
    }
}
