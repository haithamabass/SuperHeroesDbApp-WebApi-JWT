namespace JWTSuperHeroesDb.Services
{
    public class PowerService : IPowerService
    {

        private readonly SuperAppDbContext _dbContext;

        public PowerService(SuperAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //GetAll logic
        public async Task<IEnumerable<Power>> GetAll()
        {

            var power = await _dbContext.Powers.OrderBy(o => o.PowerName).ToListAsync();
            return (power);
        }


        //Get super power ById logic 
        public async Task<Power> GetById(int id)
        {
            return await _dbContext.Powers.FindAsync(id);
            
        }



        //Add new super power logic
        public async Task<Power> Add(Power model)
        {
            await _dbContext.AddAsync(model);
            _dbContext.SaveChanges();

            return model;
        }



        //Update super power
        public Power Update(Power model)
        {
            _dbContext.Update(model);
            _dbContext.SaveChanges();

            return model;

        }



        //Delete super power
        public Power Delete(Power model)
        {
            _dbContext.Remove(model);
            _dbContext.SaveChanges();
            return model;
        }


        //Check for Id validation
        public async Task<bool> IsVaidPowerId(int id)
        {
           return await _dbContext.Powers.AnyAsync(p => p.PowerId == id);

        }



        //check if the super power already exist
        public async Task<bool> IsExist(Power model)
        {
            return await _dbContext.Powers.AnyAsync(p => p.PowerName == model.PowerName);
        }
    }
}
