using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class CreateUserTaskCommand : IRequest<Guid>
    {
        public CreateUserTaskCommand(string description, string name)
        {
            Description = description;
            Name = name;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
