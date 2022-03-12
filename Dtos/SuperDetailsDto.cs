namespace JWTSuperHeroesDb.Dtos
{
    public class SuperDetailsDto
    {
        public int SuperId { get; set; }

        public string Name { get; set; }


        public string PowerName { get; set; }
        public int PowerId { get; set; }



        public string City { get; set; }

        public double Rate { get; set; }

        public byte [] Picture { get; set; }



    }
}
