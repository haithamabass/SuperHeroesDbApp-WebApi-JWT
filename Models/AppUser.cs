
namespace JWTSuperHeroesDb.Models
{

    public class AppUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }


        public List<RefreshToken>? RefreshTokens { get; set; }

    }
}
