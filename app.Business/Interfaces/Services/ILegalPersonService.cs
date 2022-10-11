using System;
using System.Threading.Tasks;

namespace app.Business.Interfaces.Services
{
    public interface ILegalPersonService
    {
        Task DeleteAsync(Guid LegalPersonId);

    }
}
