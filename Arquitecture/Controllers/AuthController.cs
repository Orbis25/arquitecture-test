using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLayer.Auth;
using DataLayer.Models.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arquitecture.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service) => _service = service;


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetUser(id);
            if (result == null) return NotFound("no encontrado");
            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {
            var result = await _service.Create(model);
            if (!result) return BadRequest(new { Message = "No se ha podido crear" });
            //201
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            var result = await _service.Login(model);
            if (!result) return BadRequest(new { Message = "usuario o contraseña erroneas" });
            return Ok(_service.BuildToken(model));
        }



    }
}
