using app.Business.Interfaces.ReadServices;
using app.Business.Interfaces.Repositories;
using app.Business.Notification;
using System.Threading.Tasks;

namespace app.Business.Services.ReadServices
{
    internal class ReadLegalPerson : NotifyService, IReadLegalPerson
    {
        public ILegalPersonRepository _legalPersonRepository;

        public ReadLegalPerson(
            ILegalPersonRepository legalPersonRepository,
            INotify notificador) : base(notificador)
        {
            _legalPersonRepository = legalPersonRepository;
        }
        public async Task HandleAsync()
        {
            Valid();
        }
        public void Valid()
        {
        }
    }
}
