using app.Business.Interfaces.Repositories;
using app.Business.Models;
using app.Data.Context;

namespace app.Data.Repository
{
    public class LegalPersonRepository : Repository<LegalPerson>, ILegalPersonRepository
    {
        public LegalPersonRepository(ApiDbContext db) : base(db)
        {
        }
    }
}
