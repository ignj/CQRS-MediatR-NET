using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetProductListHandler(DatabaseCtx ctx) : IRequestHandler<GetProductListQuery, List<Product>>
{
    public async Task<List<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        return await ctx.Products.ToListAsync(cancellationToken);
    }
}
