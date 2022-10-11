using app.Business.Models;
using System.Threading.Tasks;

namespace app.Business.Interfaces.CreateServices
{
    public interface ICreateLegalPerson
    {
        Task HandleAsync(LegalPerson legalPerson);
    }
}
