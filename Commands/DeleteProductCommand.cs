using MediatR;

public class DeleteProductCommand(int id) : IRequest<int>
{
    public int Id { get; set; } = id;
}