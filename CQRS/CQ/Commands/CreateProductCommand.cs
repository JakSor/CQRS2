using DTO;
using MediatR;

namespace CQRS.CQ.Commands
{
    public class CreateProductCommand :IRequest<bool>
    {
        public ProductDTO ProductDto { get; set; }
        public CreateProductCommand(ProductDTO productDTO)
        {
            ProductDto = productDTO;
        }
    }
}
