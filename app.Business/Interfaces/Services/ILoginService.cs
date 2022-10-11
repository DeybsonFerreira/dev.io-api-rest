using app.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Business.Interfaces.Services
{
    public interface ILoginService
    {
        Task AddAsync(Login model);
        Task<Login> GetAsync(Guid id);
        Task<List<Login>> GetAllAsync();
        Task RemoveAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, Login model);

    }
}