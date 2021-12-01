using AutoMapper;
using CQRS.CQ.Queries;
using DTO;
using MediatR;
using Repository.Interfaces;

namespace CQRS.CQ.Handler
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, ProductListDTO>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _repo = productRepository;
            _mapper = mapper;
        }

       
        public async Task<ProductListDTO> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productListDTO = await _repo.GetProducts(request.Parameters);
            var result = new ProductListDTO();
            foreach (var product in productListDTO)
            {
                result.ProductDTOs.Add(_mapper.Map<ProductDTO>(product));
            }
            return result;
        }
    }
}
