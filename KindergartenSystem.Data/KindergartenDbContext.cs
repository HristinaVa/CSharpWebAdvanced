using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KindergartenSystem.Data
{
    public class KindergartenDbContext : IdentityDbContext
    {
        public KindergartenDbContext(DbContextOptions<KindergartenDbContext> options)
            : base(options)
        {
        }
    }
}
