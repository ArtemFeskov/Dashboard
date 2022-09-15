using Dashboard.Data.Data.ViewModels;
using Dashboard.Data.Validation;
using Dashboard.Servises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard_2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserVM model)
        {
            var validator = new RegisterUserValidation();
            var validationResult = await validator.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);
                return Ok();
            }
            else
            {
                return BadRequest(validationResult.Errors);
            }
        }
    }
}
