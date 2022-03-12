namespace JWTSuperHeroesDb.Services
{
    public interface IPowerService
    {
        //GetAll logic
        Task<IEnumerable<Power>>GetAll();


        //Get super power ById logic 
        Task<Power> GetById(int id);
        

        //Add new super power logic 
        Task<Power> Add(Power model);

        //Update super power
        Power Update(Power model);

        //Delete super power
        Power Delete(Power model);


        //Check for Id validation
        Task<bool> IsVaidPowerId(int id);


        //check if the super power already exist
        Task<bool> IsExist(Power model);

        





    }
}
