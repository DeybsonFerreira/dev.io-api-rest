using app.Business.Models.Input;
using app.Business.Models.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Business.Interfaces.Services
{
    public interface INaturalPersonService
    {
        IEnumerable<NaturalPersonOutput> GetAll();
        IEnumerable<NaturalPersonOutput> Filter(Guid? naturalPersonId = null, string documentNumber = null);
        Task<NaturalPersonOutput> CreateAsync(NaturalPersonInput input);
        Task<NaturalPersonOutput> UpdateAsync(NaturalPersonInput input, Guid naturalPersonId);
        Task DeleteAsync(Guid naturalPersonId);
    }
}
