using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class CreateTagCommand : IRequest<Guid>
    {
        public CreateTagCommand(string userTaskID, string tagName)
        {
            UserTaskID = userTaskID;
            TagName = tagName;
        }

        public string UserTaskID { get; set; }
        public string TagName { get; set; }
    }
}
