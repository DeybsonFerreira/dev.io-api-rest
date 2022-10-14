using app.Business.Models;
using System;
using System.Threading.Tasks;

namespace app.Business.Interfaces.UpdateServices
{
    public interface IUpdateLegalPerson
    {
        Task<LegalPerson> HandleAsync(LegalPerson legalPerson, Guid legalPersonId);
    }
}
