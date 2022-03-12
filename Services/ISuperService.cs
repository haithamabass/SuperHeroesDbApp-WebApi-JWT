namespace JWTSuperHeroesDb.Services
{
    public interface ISuperService
    {
        //Get all Super Heroes logic
        Task<IEnumerable<SuperHero>> GetAll();


        //Get Super hero by id logic
        Task<SuperHero> GetById(int id);


        //Get Super hero by "power" id logic
        Task<IEnumerable<SuperHero>> GetByPowerId(int powerId);


        //Add new super hero logic
        Task<SuperHero> Add(SuperHero model);


        // Update super hero by using id logic
        SuperHero Update(SuperHero model);


        // Delete super hero by using id logic
        SuperHero Delete(SuperHero model);


        // check if there is a super hero has the sent "PowerId" logic
        Task<bool> HasIdPower(int powerid);



        //check if there is a hero exist with the same name
        Task<bool> HeroIsExist(string heroName);


    }
}
