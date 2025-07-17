using MediatR;
using Sonar.Application.Interfaces.Repositories;

namespace Sonar.Application.UseCases.User
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; }
        public DeleteUserCommand(int id) => Id = id;
    }

    public class DeleteUserUseCase : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _repository;

        public DeleteUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var success = await _repository.DeleteAsync(request.Id);
            return success;
        }
    }
}
