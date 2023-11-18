using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetProductByIdHandler(DatabaseCtx ctx) : IRequestHandler<GetProductByIdQuery, Product?>
{
    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await ctx.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
    }
}