using app.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Business.Interfaces.Services
{
    public interface INaturalPersonService
    {
        IEnumerable<NaturalPerson> GetAll();
        IEnumerable<NaturalPerson> Filter(Guid? naturalPersonId = null, string documentNumber = null);
        Task DeleteAsync(Guid naturalPersonId);
    }
}
