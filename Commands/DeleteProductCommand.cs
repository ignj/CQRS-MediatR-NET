using MediatR;

public class DeleteProductCommand(int id) : IRequest<Unit>
{
    public int Id { get; set; } = id;
}