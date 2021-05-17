using Beneficiary.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace Beneficiary.DataAccess
{
    public class BeneficiaryDbContext : DbContext
    {
        public BeneficiaryDbContext(DbContextOptions<BeneficiaryDbContext> options) : base(options)
        {

        }
        public DbSet<BeneficiaryModel> Beneficiaries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
