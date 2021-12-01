using MediatR;

namespace CQRS.CQ.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id= id;
        }
    }
}
