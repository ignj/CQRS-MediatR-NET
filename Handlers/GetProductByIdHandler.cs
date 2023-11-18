using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetProductByIdHandler(DatabaseCtx ctx) : IRequestHandler<GetProductByIdQuery, Product>
{
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await ctx.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (result == null) throw new NotFoundException();

        return result;
    }
}