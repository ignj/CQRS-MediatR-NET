using MediatR;

public class CreateProductHandler(DatabaseCtx ctx) : IRequestHandler<CreateProductCommand, Product>
{
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (ctx.Products.Any(p => p.Name.ToLower() == request.Name.ToLower())) throw new ConflictException($"Product {request.Name} already exists.");

        var product = new Product
        {
            Name = request.Name,
            Type = request.Type,
            WarehouseName = request.WarehouseName,
            Stock = request.Stock
        };

        await ctx.Products.AddAsync(product, cancellationToken);
        await ctx.SaveChangesAsync(cancellationToken);

        return product;
    }
}