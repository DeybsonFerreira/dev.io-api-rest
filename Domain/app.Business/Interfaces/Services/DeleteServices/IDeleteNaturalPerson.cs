using System;
using System.Threading.Tasks;

namespace app.Business.Interfaces.DeleteServices
{
    public interface IDeleteNaturalPerson
    {
        Task HandleAsync(Guid naturalPersonId);

    }
}
