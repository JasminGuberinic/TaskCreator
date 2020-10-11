using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class GetUserTasksByTagsQuery : IRequest<List<UserTask>>
    {
        public List<string> TagIDs { get; set; }

        public GetUserTasksByTagsQuery(List<string> ids)
        {
            TagIDs = ids;
        }
    }
}
