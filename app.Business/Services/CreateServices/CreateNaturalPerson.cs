using app.Business.Interfaces.CreateServices;
using app.Business.Interfaces.Repositories;
using app.Business.Notification;

namespace app.Business.Services.CreateServices
{
    internal class CreateNaturalPerson : NotifyService, ICreateNaturalPerson
    {
        public INaturalPersonRepository _naturalPersonRepository;
        public CreateNaturalPerson(
            INaturalPersonRepository naturalPersonRepository,
            INotify notification) : base(notification)

        {
            _naturalPersonRepository = naturalPersonRepository;
        }
    }
}
