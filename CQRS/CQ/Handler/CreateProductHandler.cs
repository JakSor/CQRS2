using AutoMapper;
using CQRS.CQ.Commands;
using Domain;
using MediatR;
using Repository.Interfaces;

namespace CQRS.CQ.Handler
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.ProductDto.IsFood)
            {
                var product = _mapper.Map<Food>(request.ProductDto);
                await _repo.Insert(product);
                await _repo.Save();
                return true;
            }
            else
            {
                var product = _mapper.Map<NonFood>(request.ProductDto);
                await _repo.Insert(product);
                await _repo.Save();
                return true;
            }
        }
    }
}

