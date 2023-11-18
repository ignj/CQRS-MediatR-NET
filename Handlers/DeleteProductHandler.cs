using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteProductHandler(DatabaseCtx ctx) : IRequestHandler<DeleteProductCommand, Unit>
{
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var result = await ctx.Products.Where(p => p.Id == request.Id).ExecuteDeleteAsync(cancellationToken);

        return Unit.Value;
    }
}