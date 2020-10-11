using Application;
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
    public class TagController : ControllerBase
    {
        private readonly ILogger<UserTaskController> _logger;
        private readonly IMediator _mediator;

        public TagController(ILogger<UserTaskController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("ByUserTaskId")]
        public async Task<IActionResult> GetTagByUserTaskId(string id)
        {
            var query = new GetTagsByUserTaskIDQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        [Route("Save")]
        public async Task<IActionResult> SaveTag([FromBody]CreateTagDTO userTask)
        {
            var query = new CreateTagCommand(userTask.UserTaskID, userTask.TagName);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteTag([FromRoute]string id)
        {
            var query = new DeleteTagCommand(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
