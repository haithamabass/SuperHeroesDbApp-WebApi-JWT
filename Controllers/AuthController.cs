using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTSuperHeroesDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }



        private void SetRefreshTokenInCookies(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime()
            };

           //cookieOptionsExpires = DateTime.UtcNow.AddSeconds(cookieOptions.Timeout);

            Response.Cookies.Append("refreshTokenKey", refreshToken, cookieOptions);
        }





        [HttpPost("signUp")]
        public async Task<IActionResult> SignUpAsync([FromForm] SignUp model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var result = await _authService.SignUpAsync(model);

            if (!result.ISAuthenticated)
                return BadRequest (result.Message);

            //store the refresh token in a cookie
            SetRefreshTokenInCookies(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok (result);
        }



        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromForm] Login model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var result = await _authService.LoginAsync(model);

            if (!result.ISAuthenticated)
                return BadRequest(result.Message);

            //check if the user has a refresh token or not , to store it in a cookie
            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookies(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }



        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRoleAsync(AddRoles model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);


            return Ok(model);
        }




        [HttpGet("refreshToken")]
        public async Task<IActionResult> RefreshTokenCheckAsync()
        {
            var refreshToken = Request.Cookies["refreshTokenKey"];

            var result = await _authService.RefreshTokenCheckAsync(refreshToken);

            if (!result.ISAuthenticated)
                return BadRequest(result);


            return Ok(result);
        }



        [HttpPost("revokeToken")]
        public async Task<IActionResult> RevokeTokenCheckAsync(RevokeToken model)
        {
            var refreshToken = model.Token ?? Request.Cookies["refreshTokenKey"];


            //check if there is no token 
            if (string.IsNullOrEmpty(refreshToken))
                return BadRequest("Token is required");

            var result = await _authService.RevokeTokenAsync(refreshToken);

            //check if there is a problem with "result" 
            if (!result)
                return BadRequest("Token is Invalid");

            return Ok();



        }















    }



}

