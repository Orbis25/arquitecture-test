using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLayer.Interfaces.Task;
using DataLayer.Models.Works;
using DataLayer.ViewModels.Works;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arquitecture.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        public TaskController(ITaskService service) => _service = service;


        /// <summary>
        /// get by taskId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound("no encontrado");
            return Ok(result);
        }

        //task
        [HttpPost]
        public async Task<IActionResult> Create(TaskWorkVM model)
        {
            var result = await _service.Create(model);
            if (!result) return BadRequest(new { Message = "xxx" });
            return Ok(result);
        }

        //work
        [HttpPost]
        public async Task<IActionResult> CreateWork(Work model)
        {
            var result = await _service.Create(model);
            if (!result) return BadRequest(new { Message = "xxxx" });
            return Ok(model);
        }



        //getAll
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());


    }
}
