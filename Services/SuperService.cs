namespace JWTSuperHeroesDb.Services
{
    public class SuperService : ISuperService
    {
        private readonly SuperAppDbContext _dbContext;

        public SuperService(SuperAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //Get all Super Heroes logic
        public async Task<IEnumerable<SuperHero>> GetAll()
        {

           return await _dbContext.SuperHeroes
                .OrderByDescending(s => s.Rate)
                .Include(p => p.Power)
                .ToListAsync();

           
        }




        //Get Super hero by id logic
        public async Task<SuperHero> GetById(int id)
        {
           return await _dbContext.SuperHeroes
                 .Include(p => p.Power)
                 .FirstOrDefaultAsync(s => s.SuperId == id);
        }


        //Get Super hero by "power" id logic
        public async Task<IEnumerable<SuperHero>> GetByPowerId(int powerId)
        {
           return await _dbContext.SuperHeroes
                .Where(p => p.PowerId == powerId)
                .OrderByDescending(s => s.Rate)
                .Include(p => p.Power)
                .ToListAsync();

        }



        //Add new super hero logic
        public async Task<SuperHero> Add(SuperHero model)
        {
             await _dbContext.AddAsync(model);

            _dbContext.SaveChanges();

            return model;
        }


        // Update super hero by using id logic
        public SuperHero Update(SuperHero model)
        {
            _dbContext.SuperHeroes.Update(model);

            _dbContext.SaveChanges();

            return model;
        }


        // Delete super hero by using id logic
        public SuperHero Delete(SuperHero model)
        {
            _dbContext.SuperHeroes.Remove(model);
            _dbContext.SaveChanges();

            return model;
        }


        // check if there is a super hero has the sent "PowerId" logic
        public async Task<bool> HasIdPower(int powerid)
        {
            return await _dbContext.SuperHeroes.AnyAsync(p => p.PowerId == powerid);
        }



        //check if there is a hero exist with the same name logic
        public async Task<bool> HeroIsExist(string heroName)
        {
            return await _dbContext.SuperHeroes.AnyAsync(p => p.Name == heroName);
        }
    }
}
