using MediatR;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
{
    public Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}