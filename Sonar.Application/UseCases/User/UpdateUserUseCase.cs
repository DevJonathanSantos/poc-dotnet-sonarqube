using MediatR;
using Sonar.Application.Interfaces.Repositories;

namespace Sonar.Application.UseCases.User
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public int Id { get; }
        public string Name { get; }
        public UpdateUserCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class UpdateUserUseCase : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _repository;

        public UpdateUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var success = await _repository.UpdateAsync(request.Id, request.Name);
            return success;
        }
    }
}
