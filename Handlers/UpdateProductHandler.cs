using MediatR;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
{
    Task<int> IRequestHandler<UpdateProductCommand, int>.Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}