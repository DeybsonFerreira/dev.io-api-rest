using app.Business.Interfaces.Repositories;
using app.Business.Models;
using app.Data.Context;

namespace app.Data.Repository
{
    public class NaturalPersonRepository : Repository<NaturalPerson>, INaturalPersonRepository
    {
        public NaturalPersonRepository(ApiDbContext db) : base(db)
        {
        }
    }
}
