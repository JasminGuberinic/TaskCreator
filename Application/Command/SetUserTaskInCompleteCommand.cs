using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class SetUserTaskInCompleteCommand : IRequest<string>
    {
        public SetUserTaskInCompleteCommand(string userTaskID)
        {
            UserTaskID = userTaskID;
        }

        public string UserTaskID { get; set; }
    }
}
