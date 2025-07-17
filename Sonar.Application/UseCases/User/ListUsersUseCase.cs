using MediatR;
using Sonar.Application.Interfaces.Repositories;
using Sonar.Domain.Entities;
using System.Collections.Generic;

namespace Sonar.Application.UseCases.User
{
    public class ListUsersQuery : IRequest<IEnumerable<Domain.Entities.User>>
    {
        public ListUsersQuery() { }
    }

    public class ListUsersUseCase : IRequestHandler<ListUsersQuery, IEnumerable<Domain.Entities.User>>
    {
        // Injete dependências necessárias, ex: IUserRepository
        private readonly IUserRepository _repository;

        public ListUsersUseCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Domain.Entities.User>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            // Lógica para listar usuários
            // Exemplo:
            // var users = await _repository.GetAllAsync();
            // return users.Select(u => new UserDto { ... });
            var users = await _repository.GetAllAsync();
            return users;
        }
    }
}
