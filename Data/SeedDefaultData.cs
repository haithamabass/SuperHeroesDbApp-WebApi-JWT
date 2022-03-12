namespace JWTSuperHeroesDb.Data
{
    public class SeedDefaultData
    {
       

        public enum Roles
        {
            SuperAdmin,
            Admin,
            User
        }


        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

        }





    }
}
