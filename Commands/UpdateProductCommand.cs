using MediatR;

public class UpdateProductCommand(int id, string name, string type, string warehouseName, int stock) : IRequest<int>
{
    public int Id { get; set; } = id;
    public required string Name { get; set; } = name;
    public required string Type { get; set; } = type;
    public required string WarehouseName { get; set; } = warehouseName;
    public int Stock { get; set; } = stock;
}