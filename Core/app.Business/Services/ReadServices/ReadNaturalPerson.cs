using app.Business.Interfaces.ReadServices;
using app.Business.Interfaces.Repositories;
using app.Business.Models;
using app.Business.Notification;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app.Business.Services.ReadServices
{
    public class ReadNaturalPerson : NotifyService, IReadNaturalPerson
    {
        private readonly INaturalPersonRepository _naturalPersonRepository;

        public ReadNaturalPerson(
            INaturalPersonRepository naturalPersonRepository,
            INotify notificador) : base(notificador)
        {
            _naturalPersonRepository = naturalPersonRepository;
        }
        public IEnumerable<NaturalPerson> Handle()
        {
            return _naturalPersonRepository.Query().ToList();
        }

        public IEnumerable<NaturalPerson> Handle(
            Guid? naturalPersonId = null,
            string documentNumber = null)
        {
            return FilterParameters(naturalPersonId, documentNumber);
        }

        private IEnumerable<NaturalPerson> FilterParameters(
            Guid? naturalPersonId = null,
            string documentNumber = null)
        {
            IQueryable<NaturalPerson> query = _naturalPersonRepository.Query();

            if (naturalPersonId.HasValue && naturalPersonId.Value != Guid.Empty)
                query = query.Where(a => a.Id == naturalPersonId);

            if (!string.IsNullOrEmpty(documentNumber))
                query = query.Where(a => a.DocumentNumber == documentNumber);

            return query.ToList();
        }
    }
}
