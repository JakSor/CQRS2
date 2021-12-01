using AutoMapper;
using CQRS.CQ.Commands;
using Domain;
using MediatR;
using Repository.Interfaces;

namespace CQRS.CQ.Handler
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repo;

        public UpdateProductHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product entityToUpdate;
            if (request.ProductDTO.IsFood)
            {
                entityToUpdate = _mapper.Map<Food>(request.ProductDTO);
            }
            else
            {
                entityToUpdate = _mapper.Map<NonFood>(request.ProductDTO);
            }
            _repo.Update(entityToUpdate);
            await _repo.Save();
            return true;
        }
    }
}
