using app.Business.Interfaces.DeleteServices;
using app.Business.Interfaces.Repositories;
using app.Business.Notification;
using System;
using System.Threading.Tasks;

namespace app.Business.Services.DeleteServices
{
    public class DeleteLegalPerson : NotifyService, IDeleteLegalPerson
    {
        public ILegalPersonRepository _legalPersonRepository;
        public DeleteLegalPerson(
            ILegalPersonRepository legalPersonRepository,
            INotify notification) : base(notification)
        {
            _legalPersonRepository = legalPersonRepository;
        }
        public async Task HandleAsync(Guid legalPersonId)
        {
            await _legalPersonRepository.RemoveAsync(legalPersonId);
        }
    }
}
