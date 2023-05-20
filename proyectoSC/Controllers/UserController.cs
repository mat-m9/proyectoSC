﻿using Microsoft.AspNetCore.Mvc;
using proyectoSC.ResponseModels;
using proyectoSC.Services;

namespace proyectoSC.Controllers
{
    public class UserController : Controller
    {
        private readonly IIdentityService _identityService;

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(template: ApiRoutes.User.Login)]
        public async Task<IActionResult> Login([FromBody] UserRequest request)
        {
            var authResponse = await _identityService.LoginAsync(request.mail, request.password);

            if (!authResponse.Success)
            {
                return BadRequest();
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });
        }
    }
}
