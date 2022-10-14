using app.Business.Interfaces.ReadServices;
using app.Business.Interfaces.Repositories;
using app.Business.Models;
using app.Business.Notification;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app.Business.Services.ReadServices
{
    public class ReadLegalPerson : NotifyService, IReadLegalPerson
    {
        public ILegalPersonRepository _legalPersonRepository;

        public ReadLegalPerson(
            ILegalPersonRepository legalPersonRepository,
            INotify notificador) : base(notificador)
        {
            _legalPersonRepository = legalPersonRepository;
        }
        public IEnumerable<LegalPerson> Handle(
            Guid? legalPersonId = null,
            string documentNumber = null)
        {
            return FilterParameters(legalPersonId, documentNumber);
        }

        private IEnumerable<LegalPerson> FilterParameters(Guid? legalPersonId = null,
            string documentNumber = null)
        {
            IQueryable<LegalPerson> query = _legalPersonRepository.Query();

            if (legalPersonId.HasValue && legalPersonId.Value != Guid.Empty)
                query = query.Where(a => a.Id == legalPersonId);

            if (!string.IsNullOrEmpty(documentNumber))
                query = query.Where(a => a.DocumentNumber == documentNumber);

            return query.ToList();
        }

    }
}
