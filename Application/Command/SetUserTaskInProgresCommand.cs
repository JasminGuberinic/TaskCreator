using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class SetUserTaskInProgresCommand : IRequest<string>
    {
        public SetUserTaskInProgresCommand(string userTaskID, string tagName)
        {
            UserTaskID = userTaskID;
        }

        public string UserTaskID { get; set; }
    }
}
