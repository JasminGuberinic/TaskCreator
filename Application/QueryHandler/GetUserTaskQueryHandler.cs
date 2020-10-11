using Domain;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueryHandler
{
    public class GetUserTaskQueryHandler : IRequestHandler<GetUserTaskQuery, UserTask>
    {
        private readonly IUserTaskRepository _userTaskRepository;
        public GetUserTaskQueryHandler(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }
        public Task<UserTask> Handle(GetUserTaskQuery request, CancellationToken cancellationToken)
        {
            var result = _userTaskRepository.GetById(request.UserTaskID);
            return Task.FromResult(result);
        }
    }
}
