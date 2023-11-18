using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteProductHandler(DatabaseCtx ctx) : IRequestHandler<DeleteProductCommand, int>
{
    public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return await ctx.Products.Where(p => p.Id == request.Id).ExecuteDeleteAsync(cancellationToken);
    }
}