namespace JWTSuperHeroesDb.Models
{
    public class AddRoles
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }

    }
}
