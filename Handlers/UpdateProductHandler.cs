using MediatR;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
{
    public Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}