using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class GetUserTasksByTagsQuery : IRequest<List<UserTask>>
    {
        public List<string> IDs { get; set; }

        public GetUserTasksByTagsQuery(List<string> ids)
        {
            IDs = ids;
        }
    }
}
