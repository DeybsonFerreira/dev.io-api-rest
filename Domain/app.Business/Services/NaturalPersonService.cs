using app.Business.Interfaces.CreateServices;
using app.Business.Interfaces.DeleteServices;
using app.Business.Interfaces.ReadServices;
using app.Business.Interfaces.Services;
using app.Business.Interfaces.UpdateServices;
using app.Business.Models;
using app.Business.Models.Input;
using app.Business.Models.Output;
using AutoMapper;
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
        private readonly IMapper _mapper;


        public NaturalPersonService(
         ICreateNaturalPerson createNaturalPerson,
         IReadNaturalPerson readNaturalPerson,
         IUpdateNaturalPerson updateNaturalPerson,
         IDeleteNaturalPerson deleteNaturalPerson,
         IMapper mapper
            )
        {
            _createNaturalPerson = createNaturalPerson;
            _readNaturalPerson = readNaturalPerson;
            _updateNaturalPerson = updateNaturalPerson;
            _deleteNaturalPerson = deleteNaturalPerson;
            _mapper = mapper;
        }

        public IEnumerable<NaturalPersonOutput> GetAll()
        {
            IEnumerable<NaturalPerson> result = _readNaturalPerson.Handle();
            return _mapper.Map<IEnumerable<NaturalPersonOutput>>(result);
        }

        public IEnumerable<NaturalPersonOutput> Filter(
            Guid? naturalPersonId = null,
            string documentNumber = null)
        {
            IEnumerable<NaturalPerson> result = _readNaturalPerson.Handle(naturalPersonId, documentNumber);
            return _mapper.Map<IEnumerable<NaturalPersonOutput>>(result);
        }

        public async Task<NaturalPersonOutput> CreateAsync(NaturalPersonInput input)
        {
            NaturalPerson modelToCreate = _mapper.Map<NaturalPerson>(input);
            await _createNaturalPerson.HandleAsync(modelToCreate);
            return _mapper.Map<NaturalPersonOutput>(modelToCreate);
        }

        public async Task<NaturalPersonOutput> UpdateAsync(NaturalPersonInput input, Guid naturalPersonId)
        {
            NaturalPerson modalToUpdate = _mapper.Map<NaturalPerson>(input);
            await _updateNaturalPerson.HandleAsync(modalToUpdate, naturalPersonId);
            return _mapper.Map<NaturalPersonOutput>(modalToUpdate);
        }

        public async Task DeleteAsync(Guid naturalPersonId)
        {
            await _deleteNaturalPerson.HandleAsync(naturalPersonId);
        }
    }
}
