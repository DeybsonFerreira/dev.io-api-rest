using app.Business.Interfaces.CreateServices;
using app.Business.Interfaces.DeleteServices;
using app.Business.Interfaces.ReadServices;
using app.Business.Interfaces.Services;
using app.Business.Interfaces.UpdateServices;
using app.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Business.Services
{
    public class LegalPersonService : ILegalPersonService
    {
        private readonly ICreateLegalPerson _createLegalPerson;
        private readonly IReadLegalPerson _readLegalPerson;
        private readonly IUpdateLegalPerson _updateLegalPerson;
        private readonly IDeleteLegalPerson _deleteLegalPerson;

        public LegalPersonService(
         ICreateLegalPerson createLegalPerson,
         IReadLegalPerson readLegalPerson,
         IUpdateLegalPerson updateLegalPerson,
         IDeleteLegalPerson deleteLegalPerson
            )
        {
            _createLegalPerson = createLegalPerson;
            _readLegalPerson = readLegalPerson;
            _updateLegalPerson = updateLegalPerson;
            _deleteLegalPerson = deleteLegalPerson;
        }
        public IEnumerable<LegalPerson> Filter(
        Guid? legalPersonId = null,
       string documentNumber = null)
        {
            IEnumerable<LegalPerson> result = _readLegalPerson.Handle(legalPersonId, documentNumber);
            return result;
        }

        public async Task SaveAsync()
        {
            //_createNaturalPerson.HandleAsync();
        }

        public async Task ChangeAsync()
        {
            //_updateNaturalPerson.HandleAsync();
        }

        public async Task DeleteAsync(Guid legalPersonId)
        {
            await _deleteLegalPerson.HandleAsync(legalPersonId);
        }
    }
}
