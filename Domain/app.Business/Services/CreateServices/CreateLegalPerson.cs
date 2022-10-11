using app.Business.Interfaces.CreateServices;
using app.Business.Interfaces.Repositories;
using app.Business.Models;
using app.Business.Notification;
using System.Threading.Tasks;

namespace app.Business.Services.CreateServices
{
    internal class CreateLegalPerson : NotifyService, ICreateLegalPerson
    {
        public ILegalPersonRepository _legalPersonRepository;
        public CreateLegalPerson(
            ILegalPersonRepository legalPersonRepository,
            INotify notification) : base(notification)
        {
            _legalPersonRepository = legalPersonRepository;
        }

        public async Task HandleAsync(LegalPerson legalPerson)
        {
            await ValidAsync(legalPerson);
            if (HasNotification())
                return;

            await _legalPersonRepository.AddAsync(legalPerson);
        }
        private async Task ValidAsync(LegalPerson legalPerson)
        {
            if (legalPerson is null)
                Notify("LegalPerson nulo");

            LegalPerson data = await _legalPersonRepository.GetAsync(legalPerson.Id);
            if (data is not null)
                Notify("Esta pessoa já existe cadastrada");
        }
    }
}
