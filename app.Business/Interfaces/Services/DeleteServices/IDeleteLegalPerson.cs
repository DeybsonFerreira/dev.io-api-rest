using System;
using System.Threading.Tasks;

namespace app.Business.Interfaces.DeleteServices
{
    public interface IDeleteLegalPerson
    {
        Task HandleAsync(Guid legalPersonId);
    }
}
