using app.Business.Interfaces.ReadServices;
using app.Business.Interfaces.Services;
using System.Threading.Tasks;

namespace app.Business.Services
{
    public class NaturalPersonService : INaturalPersonService
    {
        private IReadNaturalPerson _readNaturalPerson;
        public NaturalPersonService(IReadNaturalPerson readNaturalPerson)
        {
            _readNaturalPerson = readNaturalPerson;
        }

        public async Task FilterAsync()
        {

        }

        public async Task SaveAsync()
        {

        }

        public async Task ChangeAsync()
        {

        }
        public async Task DeleteAsync()
        {

        }
    }
}
