using System.Threading.Tasks;
using app.Business.Interfaces;
using app.Business.Models;
using app.Data.Context;

namespace app.Data.Repository
{
    public class LoginRepository : Repository<Login>, ILoginRepository
    {
        public LoginRepository(ApiDbContext db) : base(db)
        {
        }

    }
}