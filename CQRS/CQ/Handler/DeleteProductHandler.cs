
using CQRS.CQ.Commands;
using MediatR;
using Repository.Interfaces;

namespace CQRS.CQ.Handler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        public IProductRepository _repo { get; set; }
        public DeleteProductHandler(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _repo.GetTById(request.Id);
            if (entity != null)
            {
                _repo.Delete(request.Id);
                await _repo.Save();
                return true;
            }
            return false;
        }
    }
}
