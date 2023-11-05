
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public int Stock { get; set; }
    public required string WarehouseName { get; set; }
}