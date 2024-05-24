using Unreal.ObjectsEmitter.Interfaces.Types;

namespace Unreal.ObjectsEmitter.Interfaces;

public interface IDataTables
{
    /// <summary>
    /// Gets a data table by name.
    /// </summary>
    /// <param name="tableName">Data table name.</param>
    /// <returns>True if the table exists, false otherwise.</returns>
    bool TryGetDataTable(string tableName, out DataTable? dataTable);

    /// <summary>
    /// Adds a callback to run once a data table is found.
    /// </summary>
    /// <param name="tableName">Data table name.</param>
    /// <param name="found">Callback.</param>
    void FindDataTable(string tableName, Action<DataTable> found);

    /// <summary>
    /// Event for when a new data table is found.
    /// </summary>
    Action<DataTable>? DataTableFound { get; set; }

    /// <summary>
    /// Gets all current data tables.
    /// </summary>
    /// <returns>All data tables.</returns>
    DataTable[] GetDataTables();
}
