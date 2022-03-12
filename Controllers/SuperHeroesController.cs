

namespace JWTSuperHeroesDb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroesController : ControllerBase
    {
        private readonly ISuperService _superService;

        private readonly IPowerService _powerService;

       



        public SuperHeroesController(ISuperService superService, IPowerService powerService)
        {
            _superService = superService;
            _powerService = powerService;
            
        }


        //define the extentions and size 
        private new List<string> _allowedExtention = new List<string> { ".jpg" };
        private long _maxAllowedPicSize = 5242880;





        //Get all Super Heroes
        [Authorize]
        [HttpGet("GetAllHeroes")]
        public async Task<IActionResult> GetAllAsync()
        {
            var heroes = await _superService.GetAll();

            

            return Ok(heroes);
        }





        //Get Super hero by id
        [Authorize]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var hero = await _superService.GetById(id);

            if (hero == null)
                return NotFound($"there is no Hero with this id {id}");

            

            return Ok(hero);

        }






        //Get Super hero by "power" id
        [Authorize]
        [HttpGet("GetByPowerId")]
        public async Task<IActionResult> GetByPowerId(int powerid)
        {
            var validPower = await _powerService.IsVaidPowerId(powerid);
            
            if (!validPower)
                return BadRequest("invalid Power id ");


            // check if there is a super hero has the sent "PowerId"
            var hasPower = await _superService.HasIdPower(powerid);
            
            if (!hasPower)
                return BadRequest($"There's no hero has this power id {powerid}");


            var hero = await _superService.GetByPowerId(powerid);

           

            return Ok(hero);
        }







        //Add new super hero
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost("CreateNewHero")]
        public async Task<IActionResult> CreateAsync([FromForm] SuperDto dto)
        {

            var validPower = await _powerService.IsVaidPowerId(dto.PowerId);

            if (!validPower)
                return BadRequest("invalid Power id ");



            //check if there is a hero exist with the same name
            var existHero = await _superService.HeroIsExist(dto.Name);

            if (existHero)
                return BadRequest("Hero is Already Exist!!!");


            //check if the sent Picture from end user if it suits the allowed extentions and sizes
                if (!_allowedExtention.Contains(Path.GetExtension(dto.Picture.FileName.ToLower())))
                    return BadRequest("only jpg is allowed");

                if (dto.Picture.Length > _maxAllowedPicSize)
                    return BadRequest("max allowed size is 20M!");

                using var dataStream = new MemoryStream();

            //to read the Picture file
                await dto.Picture.CopyToAsync(dataStream);


            var hero = new SuperHero
            {
                Name = dto.Name,
                City = dto.City,
                Rate = dto.Rate,
                PowerId = dto.PowerId,
                Picture = dataStream.ToArray()


            };

            

            await _superService.Add(hero);


            return Ok(hero);

        }





        // Update super hero by using id
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPut("UpdateHero")]
        public async Task<IActionResult> UpdateAsync([FromForm] SuperDto dto, int id)
        {
            var hero = await _superService.GetById(id);

            if (hero == null)
                return BadRequest($"There's no user with this Id {id}");

            var validPower = await _powerService.IsVaidPowerId(dto.PowerId);
            if (!validPower)
                return BadRequest("invalid Power id ");


            //in case there is no update for "Picture" == null
            if(dto.Picture != null)
            {

            if (!_allowedExtention.Contains(Path.GetExtension(dto.Picture.FileName.ToLower())))
                return BadRequest("only jpg is allowed");

            if (dto.Picture.Length > _maxAllowedPicSize)
                return BadRequest("max allowed size is 20M!");

            var datastream = new MemoryStream();
            await dto.Picture.CopyToAsync(datastream);
            }

            hero.Name = dto.Name;
            hero.City = dto.City;
            hero.Rate = dto.Rate;
            hero.PowerId = dto.PowerId;





            _superService.Update(hero);

            return Ok(hero);

        }



        // Delete super hero by using id
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var hero = await _superService.GetById(id);

            if (hero == null)
                return BadRequest($"There's no user with this Id {id}");

            _superService.Delete(hero);

            return Ok(hero);
        }







    }
}
