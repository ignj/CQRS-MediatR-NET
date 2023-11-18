using MediatR;
using Microsoft.EntityFrameworkCore;

public class UpdateProductHandler(DatabaseCtx ctx) : IRequestHandler<UpdateProductCommand, Unit>
{
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var result = await ctx.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (result == null) throw new NotFoundException();
        if (await ctx.Products.AnyAsync(p => p.Name == result.Name && p.Id != result.Id, cancellationToken))
            throw new ConflictException($"Product {request.Name} already exists.");

        result.WarehouseName = request.WarehouseName;
        result.Name = request.Name;
        result.Stock = request.Stock;
        result.Type = request.Type;

        ctx.Update(result);
        await ctx.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}