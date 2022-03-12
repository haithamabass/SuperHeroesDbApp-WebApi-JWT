namespace JWTSuperHeroesDb.Services
{
    public interface IAuthService
    {
        //For signup logic
        Task<AuthModel> SignUpAsync(SignUp model);

        //For login logic
        Task<AuthModel> LoginAsync(Login model);

        //for addroles logic 
        Task<string> AddRoleAsync(AddRoles model);

        //for checking if the sent token is valid
        Task<AuthModel> RefreshTokenCheckAsync(string token);

        // for revoking refreshrokens
        Task<bool> RevokeTokenAsync(string token);

    }
}
