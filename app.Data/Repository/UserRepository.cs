using app.Business.Interfaces.Repositories;
using app.Business.Models;
using app.Data.Context;

namespace app.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApiDbContext db) : base(db)
        {
        }
    }
}