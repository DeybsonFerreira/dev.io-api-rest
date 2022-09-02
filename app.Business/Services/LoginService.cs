using app.Business.Interfaces;
using app.Business.Models;
using app.Business.Notification;
using app.Business.Validation.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Business.Services
{
    public class LoginService : NotifyService, ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IUserRepository _userRepository;
        public LoginService(ILoginRepository loginRepository, IUserRepository userRepository, INotify notificador) : base(notificador)
        {
            _loginRepository = loginRepository;
            _userRepository = userRepository;
        }

        public async Task<Login> GetAsync(Guid id)
        {
            return await _loginRepository.GetAsync(id);
        }

        public async Task<List<Login>> GetAllAsync()
        {
            return await _loginRepository.GetAllAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            IEnumerable<Login> existent = await _loginRepository.Find(e => e.Id == id);

            if (!existent.Any())
            {
                base.Notify("Login não encontrado");
                return;
            }
            await _loginRepository.RemoveAsync(id);
        }

        public async Task<bool> UpdateAsync(Guid id, Login model)
        {
            List<string> erros = UpdateLoginValidation.ValidParams(id, model);
            if (erros.Any())
            {
                Notify(erros);
                return false;
            }

            Login loginDb = await _loginRepository.GetAsync(id);
            User userDb = await _userRepository.GetAsync(model.UserId);
            List<string> errorData = UpdateLoginValidation.ValidRequiredDataToUpdate(loginDb, userDb);

            if (errorData.Any())
            {
                Notify(errorData);
                return false;
            }

            loginDb.Username = model.Username;
            loginDb.Password = model.Password;
            loginDb.UserId = model.UserId;

            await _loginRepository.UpdateAsync(loginDb);
            return true;
        }

        public async Task AddAsync(Login model)
        {
            User userDb = await _userRepository.GetAsync(model.UserId);
            List<string> errorData = CreateLoginValidation.ValidRequiredDataToCreate(userDb);
            if (errorData.Any())
            {
                Notify(errorData);
                return;
            }

            var query = _loginRepository.Query();
            List<string> errorDataExistent = CreateLoginValidation.ValidateExistent(query, model);
            if (errorDataExistent.Any())
            {
                Notify(errorDataExistent);
                return;
            }
            await _loginRepository.AddAsync(model);
        }

    }
}