using app.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Data.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
        public DbSet<LegalPerson> LegalPerson { get; set; }
        public DbSet<NaturalPerson> NaturalPerson { get; set; }
    }
}
