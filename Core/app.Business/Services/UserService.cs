using app.Business.Interfaces.Repositories;
using app.Business.Interfaces.Services;
using app.Business.Models;
using app.Business.Notification;
using app.Business.Validation.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Business.Services
{
    public class UserService : NotifyService, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, INotify notificador) : base(notificador)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            IEnumerable<User> existent = await _userRepository.Find(e => e.Id == id);

            if (!existent.Any())
            {
                base.Notify("Usuário não encontrado");
                return;
            }
            await _userRepository.RemoveAsync(id);
        }

        public async Task<bool> UpdateAsync(Guid id, User model)
        {
            List<string> erros = UpdateUserValidation.ValidParams(id, model);
            if (erros.Any())
            {
                Notify(erros);
                return false;
            }

            User userDb = await _userRepository.GetAsync(id);
            List<string> errorData = UpdateUserValidation.ValidRequiredDataToUpdate(userDb);

            if (errorData.Any())
            {
                Notify(errorData);
                return false;
            }

            userDb.FirstName = model.FirstName;
            userDb.LastName = model.LastName;
            userDb.IsActive = model.IsActive;

            await _userRepository.UpdateAsync(userDb);
            return true;
        }

        public async Task AddAsync(User model)
        {
            await _userRepository.AddAsync(model);
        }
    }
}