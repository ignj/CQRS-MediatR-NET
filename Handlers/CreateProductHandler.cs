using MediatR;

public class CreateProductHandler(DatabaseCtx ctx) : IRequestHandler<CreateProductCommand, Product>
{
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // if (ctx.Products.Any(p => p.Name.ToLower() == request.Name.ToLower())) return 409; make response wrapper
        var product = new Product
        {
            Name = request.Name,
            Type = request.Type,
            WarehouseName = request.WarehouseName
        };

        await ctx.Products.AddAsync(product, cancellationToken);
        await ctx.SaveChangesAsync(cancellationToken);

        return product;
    }
}