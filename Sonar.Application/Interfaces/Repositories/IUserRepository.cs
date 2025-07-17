using System.Collections.Generic;
using System.Threading.Tasks;
using Sonar.Application.UseCases.User;
using Sonar.Domain.Entities;

namespace Sonar.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> CreateAsync(string name);
        Task<bool> UpdateAsync(int id, string name);
        Task<bool> DeleteAsync(int id);
    }
}
