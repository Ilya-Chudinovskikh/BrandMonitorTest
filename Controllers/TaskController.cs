using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrandMonitorTest.Data;
using BrandMonitorTest.Models.Entities;
using BrandMonitorTest.Services;

namespace BrandMonitorTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        public TaskController(ITaskService service)
        {
            _service = service;
        }

        // GET: api/task/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskEntity>> GetTaskAsync(string id)
        {
            if(Guid.TryParse(id, out var validGuid))
            {
                var taskEntity = await _service.FindTaskByIdAsync(validGuid);

                if (taskEntity == null)
                {
                    return NotFound();
                }

                return Ok(taskEntity.Status.ToString());
            }

            return BadRequest();
        }

        // POST: api/task
        [HttpPost]
        public async Task<ActionResult<Guid>> PostTaskAsync()
        {
            var task = await _service.AddTaskAsync();

            Response.OnCompleted(async () =>
            {
                await _service.UpdateTaskAsync(task);
            });

            return Accepted(task.Id);
        }
    }
}
