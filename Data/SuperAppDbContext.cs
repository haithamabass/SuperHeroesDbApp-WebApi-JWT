namespace JWTSuperHeroesDb.Data
{
    public class SuperAppDbContext : DbContext
    {
        public SuperAppDbContext(DbContextOptions<SuperAppDbContext> options) : base(options)
        {


        }

        public DbSet<Power> Powers { get; set; }
        public DbSet<SuperHero> SuperHeroes { get; set; }









    }
}
