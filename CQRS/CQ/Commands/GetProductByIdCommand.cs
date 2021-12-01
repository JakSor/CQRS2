using DTO;
using MediatR;

namespace CQRS.CQ.Commands
{
    public class GetProductByIdCommand :IRequest<ProductDTO>
    {
        public int Id { get; set; }
        public GetProductByIdCommand(int id)
        {
            Id = id;
        }
    }
}
