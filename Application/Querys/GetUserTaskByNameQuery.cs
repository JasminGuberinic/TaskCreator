using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class GetUserTaskByNameQuery : IRequest<UserTask>
    {
        public string UserTaskName { get; set; }

        public GetUserTaskByNameQuery(string name)
        {
            UserTaskName = name;
        }
    }
}
