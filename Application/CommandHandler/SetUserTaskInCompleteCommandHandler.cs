using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    class SetUserTaskInCompleteCommandHandler : IRequestHandler<SetUserTaskInCompleteCommand, string>
    {
        private readonly IUserTaskRepository _userTaskRepository;
        public SetUserTaskInCompleteCommandHandler(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }

        public async Task<string> Handle(SetUserTaskInCompleteCommand request, CancellationToken cancellationToken)
        {
            for (int i = 0; i < 100000000; i++)
            {
            }
            await _userTaskRepository.SetUserTaskInCompleted(request.UserTaskID);
            return request.UserTaskID;
        }
    }
}