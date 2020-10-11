using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class GetUserTasksByTagsNamesQuery : IRequest<List<UserTask>>
    {
        public List<string> TagNames { get; set; }

        public GetUserTasksByTagsNamesQuery(List<string> names)
        {
            TagNames = names;
        }
    }
}
