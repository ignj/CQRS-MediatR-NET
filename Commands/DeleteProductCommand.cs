using MediatR;

public class DeleteProductCommand : IRequest<Unit>
{
    public int Id { get; set; }
}