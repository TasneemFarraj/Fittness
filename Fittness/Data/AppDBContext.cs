using Fittness.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Fittness.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }
        public DbSet <Category> Categories { get; set; }
        public DbSet<Palate1> Palates1 { get; set; }

        public DbSet<PalateImg> PalatesImg { get; set;}

        public DbSet<PalateNutrition> PalateNutritions { get; set; }
        public DbSet<PalateRecipe> PalateRecipes{ get; set; }
        public DbSet<PalateIngredient> PalateIngredients { get; set; }
        public DbSet<PalatePrepare> PalatePrepares { get; set; }

    }

}
