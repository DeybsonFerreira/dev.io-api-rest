using app.Business.Interfaces.ReadServices;
using app.Business.Interfaces.Repositories;
using app.Business.Notification;

namespace app.Business.Services.ReadServices
{
    internal class ReadNaturalPerson : NotifyService, IReadNaturalPerson
    {
        public INaturalPersonRepository _naturalPersonRepository;

        public ReadNaturalPerson(INotify notificador) : base(notificador)
        {
        }
    }
}
