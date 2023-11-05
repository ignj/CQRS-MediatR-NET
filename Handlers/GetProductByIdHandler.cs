using MediatR;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}