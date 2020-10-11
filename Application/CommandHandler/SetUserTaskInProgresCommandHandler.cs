using Domain;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class SetUserTaskInProgresCommandHandler : IRequestHandler<SetUserTaskInProgresCommand, string>
    {
        private readonly IUserTaskRepository _userTaskRepository;
        private readonly IMediator _mediator;

        public SetUserTaskInProgresCommandHandler(IUserTaskRepository userTaskRepository, IMediator mediator)
        {
            _userTaskRepository = userTaskRepository;
            _mediator = mediator;
        }

        public async Task<string> Handle(SetUserTaskInProgresCommand request, CancellationToken cancellationToken)
        {
            if(_userTaskRepository.IsThereInProgressTask())
            {
                throw new OnlyOneTaskInProgressException("There is task in progress");
            }

            await _userTaskRepository.SetUserTaskInProgress(request.UserTaskID);
            var command = new SetUserTaskInCompleteCommand(request.UserTaskID);
            await _mediator.Send(command);

            return request.UserTaskID;
        }
    }
}
