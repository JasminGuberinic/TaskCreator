using Application;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize]
        [Route("ById")]
        public async Task<IActionResult> GetUserTaskById(string id)
        {
            var query = new GetUserTaskQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("ByName")]
        public async Task<IActionResult> GetUserTaskByName(string name)
        {
            var query = new GetUserTaskByNameQuery(name);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        
        [HttpPut]
        [Route("Save")]
        public async Task<IActionResult> SaveUserTask([FromBody]UserTaskDTO userTask)
        {
            var query = new CreateUserTaskCommand(userTask.Description, userTask.Name);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        
        [HttpPut]
        [Route("ChangeStatus")]
        public async Task<IActionResult> ChangeTaskStatus([FromRoute]string userTaskId)
        {
            var query = new SetUserTaskInProgresCommand(userTaskId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        [Route("GetByTags")]
        public async Task<IActionResult> GetUserTaskByTags([FromBody]TagIDsListDTO tags)
        {
            var query = new GetUserTasksByTagsQuery(tags.ListTagsIds);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        [Route("GetByTagsNames")]
        public async Task<IActionResult> GetUserTaskByTagsnames([FromBody]TagsNamesDTO tags)
        {
            var query = new GetUserTasksByTagsNamesQuery(tags.TagNames);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
