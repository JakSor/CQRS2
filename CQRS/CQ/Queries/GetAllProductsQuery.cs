using Domain.Parameters;
using DTO;
using MediatR;

namespace CQRS.CQ.Queries
{
    public class GetAllProductsQuery: IRequest <ProductListDTO>
    {
        public ProductParameters Parameters { get; set; }
        public GetAllProductsQuery(ProductParameters parameters)
        {
            Parameters = parameters;
        }
    }
}
