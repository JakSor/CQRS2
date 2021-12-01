using DTO;
using MediatR;

namespace CQRS.CQ.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public ProductDTO ProductDTO { get; set;}

        public UpdateProductCommand(ProductDTO product)
        {
            ProductDTO = product;
        }
    }
}
