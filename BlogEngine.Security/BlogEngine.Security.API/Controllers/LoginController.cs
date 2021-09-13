using AutoMapper;
using BlogEngine.Security.API.Models;
using BlogEngine.Security.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

using Service = BlogEngine.Security.Services.Models;

namespace BlogEngine.Security.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public LoginController(IMapper mapper,
            IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        public ActionResult GetToken([FromBody] GetTokenRequest request)
        {
            var parameters = _mapper.Map<Service.GetTokenParameters>(request);

            var result = _userService.GetToken(parameters);

            if (result == null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
