using Domain;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class GetUserTaskByNameQueryHandler : IRequestHandler<GetUserTaskByNameQuery, UserTask>
    {
        private readonly IUserTaskRepository _userTaskRepository;
        public GetUserTaskByNameQueryHandler(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }
        public Task<UserTask> Handle(GetUserTaskByNameQuery request, CancellationToken cancellationToken)
        {
            var result = _userTaskRepository.GetByName(request.Name);
            return Task.FromResult(result);
        }
    }
}
