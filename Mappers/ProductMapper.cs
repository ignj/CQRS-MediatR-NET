using Riok.Mapperly.Abstractions;

[Mapper]
public partial class ProductMapper
{
    public partial ReadProductOutboundDto ProductToReadProductOutboundDto(Product product);
    public partial List<ReadProductOutboundDto> ProductToReadProductOutboundDtoList(List<Product> products);
}