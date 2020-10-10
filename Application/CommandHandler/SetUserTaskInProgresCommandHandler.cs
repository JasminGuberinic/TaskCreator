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
        public SetUserTaskInProgresCommandHandler(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }

        public Task<string> Handle(SetUserTaskInProgresCommand request, CancellationToken cancellationToken)
        {
            var usetTask =  _userTaskRepository.GetById(request.UserTaskID);
            usetTask.TaskStatus = Domain.TaskStatus.INPROGRESS;
            return Task.FromResult(request.UserTaskID);
        }
    }
}
