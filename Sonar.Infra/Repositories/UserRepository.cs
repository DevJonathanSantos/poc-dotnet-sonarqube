using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sonar.Application.Interfaces.Repositories;
using Sonar.Domain.Entities;

namespace Sonar.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        // Exemplo de armazenamento em memória
        private static readonly List<User> _users = new();
        private static int _nextId = 1;

        public async Task<User> GetByIdAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return await Task.FromResult(user == null ? null : new User { Id = user.Id, Name = user.Name });
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(_users.Select(u => new User { Id = u.Id, Name = u.Name }));
        }

        public async Task<User> CreateAsync(string name)
        {
            var user = new User { Id = _nextId++, Name = name };
            _users.Add(user);
            return await Task.FromResult(new User { Id = user.Id, Name = user.Name });
        }

        public async Task<bool> UpdateAsync(int id, string name)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return await Task.FromResult(false);
            user.Name = name;
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return await Task.FromResult(false);
            _users.Remove(user);
            return await Task.FromResult(true);
        }
    }
}
