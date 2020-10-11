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
        public SetUserTaskInProgresCommandHandler(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }

        public async Task<string> Handle(SetUserTaskInProgresCommand request, CancellationToken cancellationToken)
        {
            if(_userTaskRepository.IsThereInProgressTask())
            {
                throw new OnlyOneTaskInProgressException("There is task in progress");
            }

            await _userTaskRepository.SetUserTaskInProgress(request.UserTaskID);

            RunTaskSetInProgress(request.UserTaskID);

            return request.UserTaskID;
        }

        void RunTaskSetInProgress(string userTaskID)
        {
            Task.Run(async () =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                }
                await _userTaskRepository.SetUserTaskInCompleted(userTaskID);
            });
        }
    }
}
