using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class GetTagsByUserTaskIDQuery : IRequest<List<Tag>>
    {
        public string UserTaskID { get; set; }

        public GetTagsByUserTaskIDQuery(string id)
        {
            UserTaskID = id;
        }
    }
}
