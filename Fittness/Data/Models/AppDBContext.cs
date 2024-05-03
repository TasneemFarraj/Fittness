using Fittness.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fittness.Data
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Card> Cards { get; set; }

        public DbSet<Frequently_question> Frequently_questions { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Palate1> Palates1 { get; set; }

        public DbSet<PalateImg> PalatesImg { get; set;}

        public DbSet<PalateNutrition> PalateNutritions { get; set; }
        public DbSet<PalateRecipe> PalateRecipes{ get; set; }
        public DbSet<PalateIngredient> PalateIngredients { get; set; }
        public DbSet<PalatePrepare> PalatePrepares { get; set; }

    }

}
