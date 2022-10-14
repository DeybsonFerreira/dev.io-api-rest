using app.Business.Models;
using System;
using System.Threading.Tasks;

namespace app.Business.Interfaces.UpdateServices
{
    public interface IUpdateNaturalPerson
    {
        Task<NaturalPerson> HandleAsync(NaturalPerson naturalPerson, Guid naturalPersonId);
    }
}
