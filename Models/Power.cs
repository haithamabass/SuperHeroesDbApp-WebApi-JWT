using System.ComponentModel.DataAnnotations.Schema;

namespace JWTSuperHeroesDb.Models
{
    [Table("Powers",Schema ="Data")]
    public class Power
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PowerId { get; set; }


        [Required]
        [MaxLength(100)]
        public string PowerName { get; set; }




    }
}
