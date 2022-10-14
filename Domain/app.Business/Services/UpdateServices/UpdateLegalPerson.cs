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
    public class UpdateLegalPerson : NotifyService, IUpdateLegalPerson
    {
        private readonly ILegalPersonRepository _legalPersonRepository;

        public UpdateLegalPerson(
            ILegalPersonRepository legalPersonRepository,
            INotify notification) : base(notification)
        {
            _legalPersonRepository = legalPersonRepository;
        }

        public async Task<LegalPerson> HandleAsync(LegalPerson legalPerson, Guid legalPersonId)
        {
            IEnumerable<LegalPerson> result = await _legalPersonRepository.FindAsync(i => i.Id == legalPersonId);
            LegalPerson data = result.FirstOrDefault();
            if (data is null)
            {
                base.Notify("Pessoa Jurídica não encontrada");
                return null;
            }

            data.FirstName = legalPerson.FirstName;
            data.LastName = legalPerson.LastName;
            data.DocumentNumber = legalPerson.DocumentNumber;
            return data;
        }
    }
}
