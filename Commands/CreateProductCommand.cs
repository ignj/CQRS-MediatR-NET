using MediatR;

public class CreateProductCommand(string name, string type, string warehouseName, int stock) : IRequest<Product>
{
    public required string Name { get; set; } = name;
    public required string Type { get; set; } = type;
    public required string WarehouseName { get; set; } = warehouseName;
    public int Stock { get; set; } = stock;
}