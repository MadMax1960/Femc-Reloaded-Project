namespace Unreal.ObjectsEmitter.Interfaces.Types;

public unsafe class DataTable
{
    public DataTable(string name, UDataTable* obj, Row[] rows)
    {
        this.Name = name;
        this.Self = obj;
        this.Rows = rows;
    }

    public string Name { get; set; }

    public UDataTable* Self { get; set; }

    public Row[] Rows { get; set; }
}

public unsafe class Row
{
    public Row(string name, UObject* obj)
    {
        this.Name = name;
        this.Self = obj;
    }

    public string Name { get; set; }

    public UObject* Self { get; set; }
}
