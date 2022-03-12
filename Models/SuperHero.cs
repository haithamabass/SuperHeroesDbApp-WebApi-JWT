namespace JWTSuperHeroesDb.Models
{
    [Table("SuperHeroes", Schema = "Data")]
    public class SuperHero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SuperId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public double Rate { get; set; }

        public byte[] Picture { get; set; }

        [ForeignKey("Power")]
        public int PowerId { get; set; }
        public Power Power { get; set; }





    }
}
