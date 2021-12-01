using AutoMapper;
using CQRS.CQ.Commands;
using DTO;
using MediatR;
using Repository.Interfaces;

namespace CQRS.CQ.Handler
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdCommand, ProductDTO>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repo;
        public GetProductByIdHandler(IMapper mapper, IProductRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ProductDTO> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            var ProductDTO = _mapper.Map<ProductDTO>(await _repo.GetTById(request.Id));
            return ProductDTO;
        }
    }
}
