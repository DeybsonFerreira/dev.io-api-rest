using app.Business.Interfaces.CreateServices;
using app.Business.Interfaces.DeleteServices;
using app.Business.Interfaces.ReadServices;
using app.Business.Interfaces.Services;
using app.Business.Interfaces.UpdateServices;
using app.Business.Models;
using app.Business.Models.Input;
using app.Business.Models.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Business.Services
{
    public class NaturalPersonService : INaturalPersonService
    {
        private readonly ICreateNaturalPerson _createNaturalPerson;
        private readonly IReadNaturalPerson _readNaturalPerson;
        private readonly IUpdateNaturalPerson _updateNaturalPerson;
        private readonly IDeleteNaturalPerson _deleteNaturalPerson;

        public NaturalPersonService(
         ICreateNaturalPerson createNaturalPerson,
         IReadNaturalPerson readNaturalPerson,
         IUpdateNaturalPerson updateNaturalPerson,
         IDeleteNaturalPerson deleteNaturalPerson
            )
        {
            _createNaturalPerson = createNaturalPerson;
            _readNaturalPerson = readNaturalPerson;
            _updateNaturalPerson = updateNaturalPerson;
            _deleteNaturalPerson = deleteNaturalPerson;
        }

        public IEnumerable<NaturalPerson> GetAll()
        {
            IEnumerable<NaturalPerson> result = _readNaturalPerson.Handle();
            return result;
        }

        public IEnumerable<NaturalPerson> Filter(
            Guid? naturalPersonId = null,
            string documentNumber = null)
        {
            IEnumerable<NaturalPerson> result = _readNaturalPerson.Handle(naturalPersonId, documentNumber);
            return result;
        }

        public async Task<NaturalPersonOutput> SaveAsync(NaturalPersonInput input)
        {
            //_createNaturalPerson.HandleAsync();
            return null;
        }

        public async Task<NaturalPersonOutput> ChangeAsync()
        {
            //_updateNaturalPerson.HandleAsync();
            return null;

        }

        public async Task DeleteAsync(Guid naturalPersonId)
        {
            await _deleteNaturalPerson.HandleAsync(naturalPersonId);
        }
    }
}
