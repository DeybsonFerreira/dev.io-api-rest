using app.Business.Models;
using System.Threading.Tasks;

namespace app.Business.Interfaces.CreateServices
{
    public interface ICreateNaturalPerson
    {
        Task HandleAsync(NaturalPerson naturalPerson);
    }
}
