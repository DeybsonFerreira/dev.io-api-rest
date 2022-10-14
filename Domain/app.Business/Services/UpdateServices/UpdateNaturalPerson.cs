using app.Business.Interfaces.Repositories;
using app.Business.Interfaces.UpdateServices;
using app.Business.Models;
using app.Business.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Business.Services.UpdateServices
{
    public class UpdateNaturalPerson : NotifyService, IUpdateNaturalPerson
    {
        private readonly INaturalPersonRepository _naturalPersonRepository;

        public UpdateNaturalPerson(
            INaturalPersonRepository naturalPersonRepository,
            INotify notification) : base(notification)
        {
            _naturalPersonRepository = naturalPersonRepository;
        }

        public async Task<NaturalPerson> HandleAsync(NaturalPerson naturalPerson, Guid naturalPersonId)
        {
            IEnumerable<NaturalPerson> result = await _naturalPersonRepository.FindAsync(i => i.Id == naturalPersonId);
            NaturalPerson data = result.FirstOrDefault();
            if (data is null)
            {
                base.Notify("Pessoa Física não encontrada");
                return null;
            }

            data.FirstName = naturalPerson.FirstName;
            data.LastName = naturalPerson.LastName;
            data.DocumentNumber = naturalPerson.DocumentNumber;

            return data;
        }
    }
}
