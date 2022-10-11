using app.Business.Interfaces.DeleteServices;
using app.Business.Interfaces.Repositories;
using app.Business.Notification;
using System;
using System.Threading.Tasks;

namespace app.Business.Services.DeleteServices
{
    public class DeleteNaturalPerson : NotifyService, IDeleteNaturalPerson
    {
        public INaturalPersonRepository _naturalPersonRepository;
        public DeleteNaturalPerson(
            INaturalPersonRepository naturalPersonRepository,
            INotify notification) : base(notification)

        {
            _naturalPersonRepository = naturalPersonRepository;
        }

        public async Task HandleAsync(Guid naturalPersonId)
        {
            await _naturalPersonRepository.RemoveAsync(naturalPersonId);
        }

    }
}
