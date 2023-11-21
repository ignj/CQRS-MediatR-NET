public class CreateProductInboundDto
{
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string WarehouseName { get; set; }
    public int Stock { get; set; }
}