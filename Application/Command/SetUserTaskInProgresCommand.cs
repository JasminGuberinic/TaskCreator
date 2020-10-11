using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class SetUserTaskInProgresCommand : IRequest<string>
    {
        public SetUserTaskInProgresCommand(string userTaskID)
        {
            UserTaskID = userTaskID;
        }

        public string UserTaskID { get; set; }
    }
}
