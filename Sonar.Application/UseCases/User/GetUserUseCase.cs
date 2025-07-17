using MediatR;
using Sonar.Application.Interfaces.Repositories;
using Sonar.Domain.Entities;

namespace Sonar.Application.UseCases.User
{
    public class GetUserQuery : IRequest<Domain.Entities.User>
    {
        public int Id { get; }
        public GetUserQuery(int id) => Id = id;
    }

    public class GetUserUseCase : IRequestHandler<GetUserQuery, Domain.Entities.User>
    {
        private readonly IUserRepository _repository;

        public GetUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            return user;
        }
    }
}
