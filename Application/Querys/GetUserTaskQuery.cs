using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class GetUserTaskQuery : IRequest<UserTask>
    {
        public string ID { get; set; }

        public GetUserTaskQuery(string id)
        {
            ID = id;
        }
    }
}
