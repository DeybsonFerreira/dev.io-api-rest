using app.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Business.Interfaces
{
    public interface IUserService
    {
        Task AddAsync(User model);
        Task<User> GetAsync(Guid id);
        Task<List<User>> GetAllAsync();
        Task RemoveAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, User model);

    }
}