using app.Business.Interfaces.CreateServices;
using app.Business.Interfaces.Repositories;
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

        public async Task HandleAsync()
        {
            Valid();
        }
        public void Valid()
        {

        }
    }
}
