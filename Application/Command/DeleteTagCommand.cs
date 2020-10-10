using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class DeleteTagCommand : IRequest<string>
    {
        public DeleteTagCommand(string id, string tagName)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
