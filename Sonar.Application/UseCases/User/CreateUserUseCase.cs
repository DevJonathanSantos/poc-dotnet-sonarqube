using MediatR;
using Sonar.Application.Interfaces.Repositories;
using Sonar.Domain.Entities;

namespace Sonar.Application.UseCases.User
{
    public class CreateUserCommand : IRequest<Domain.Entities.User>
    {
        public string Name { get; }
        public CreateUserCommand(string name) => Name = name;
    }

    public class CreateUserUseCase : IRequestHandler<CreateUserCommand, Domain.Entities.User>
    {
        private readonly IUserRepository _repository;

        public CreateUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.CreateAsync(request.Name);
            return user;
        }
    }
}
