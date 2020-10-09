using Application;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserTaskController : ControllerBase
    {
        private readonly ILogger<UserTaskController> _logger;
        private readonly IMediator _mediator;

        public UserTaskController(ILogger<UserTaskController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        ///<summary>This gets orders </summary>
        ///<reeturns>integer</returns>
        [HttpGet]
        public async Task<IActionResult> GetUserTask(string id)
        {
            var query = new GetUserTaskQuery(id);
            var result = _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> GetUserTask([FromBody]UserTaskDTO userTask)
        {
            var query = new CreateUserTaskCommand(userTask.Description, userTask.Name);
            var result = _mediator.Send(query);
            return Ok(result);
        }
    }
}
