using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoadRunner.Core.Models.APIModels;
using RoadRunner.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadRunner.Core.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private UserRepository _userRepository;

        public AuthenticationController(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationAPIModel model)
        {
            var response = _userRepository.Authenticate(model.UserName, model.Password);

            if (response == null)
                return BadRequest(new { error = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
