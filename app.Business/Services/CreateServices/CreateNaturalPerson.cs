using app.Business.Interfaces.CreateServices;
using app.Business.Interfaces.Repositories;
using app.Business.Models;
using app.Business.Notification;
using System.Threading.Tasks;

namespace app.Business.Services.CreateServices
{
    public class CreateNaturalPerson : NotifyService, ICreateNaturalPerson
    {
        public INaturalPersonRepository _naturalPersonRepository;
        public CreateNaturalPerson(
            INaturalPersonRepository naturalPersonRepository,
            INotify notification) : base(notification)

        {
            _naturalPersonRepository = naturalPersonRepository;
        }

        public async Task HandleAsync(NaturalPerson naturalPerson)
        {
            await ValidAsync(naturalPerson);
            if (HasNotification())
                return;

            await _naturalPersonRepository.AddAsync(naturalPerson);
        }
        private async Task ValidAsync(NaturalPerson naturalPerson)
        {
            if (naturalPerson is null)
                Notify("naturalPerson nulo");

            NaturalPerson data = await _naturalPersonRepository.GetAsync(naturalPerson.Id);
            if (data is not null)
                Notify("Esta pessoa já existe cadastrada");
        }
    }
}
