

namespace JWTSuperHeroesDb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PowersController : ControllerBase
    {


        private readonly IPowerService _powerService;

        public PowersController(IPowerService powerService)
        {
            _powerService = powerService;
        }





        //Get All super powers
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpGet("GetAllPowers")]
        public async Task<IActionResult> GetAllAsunc()
        {
            var power = await _powerService.GetAll();
            return Ok(power);
        }


        [Authorize(Roles = "SuperAdmin, Admin")]
        // Get super power by id
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var power =await _powerService.GetById(id);
            return Ok(power);
        }





        // add new super power
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("AddPower")]
        public async Task<IActionResult> CreateAsync( Power model)
        {
            var power = new Power { PowerName = model.PowerName };


            if( await _powerService.IsExist(power))
                return BadRequest("Already Registered");

           await _powerService.Add(power);

            return Ok(power);
        }



         //update the super power by using id
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(Power model, int id)
        {
            var power = await _powerService.GetById(id);

            if(power == null)
            {
                return NotFound($"No super power was found with ID {id}");
            }

            power.PowerName = model.PowerName;

            if (await _powerService.IsExist(model))
                return BadRequest("Already Registered");


            _powerService.Update(power);

            return Ok(power);

        }



        // delete the super power by using id
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync (int id)
        {
            var power = await _powerService.GetById(id);

            if (power == null)
            {
                return NotFound($"No super power was found with ID {id}");
            }


            _powerService.Delete(power);

            return Ok(power);

        }










    }
}
