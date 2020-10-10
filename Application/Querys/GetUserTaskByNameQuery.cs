using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class GetUserTaskByNameQuery : IRequest<UserTask>
    {
        public string Name { get; set; }

        public GetUserTaskByNameQuery(string name)
        {
            Name = name;
        }
    }
}
