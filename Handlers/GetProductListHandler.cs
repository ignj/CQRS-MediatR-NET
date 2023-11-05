using MediatR;

public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<Product>>
{
    public Task<List<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
