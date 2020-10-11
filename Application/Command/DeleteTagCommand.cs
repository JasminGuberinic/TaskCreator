using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class DeleteTagCommand : IRequest<string>
    {
        public DeleteTagCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
