using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueryHandler
{
    public class GetUserTaskQueryHandler : IRequestHandler<GetUserTaskQuery, string>
    {
        private readonly IUserTaskRepository _userTaskRepository;
        public GetUserTaskQueryHandler(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }
        public Task<string> Handle(GetUserTaskQuery request, CancellationToken cancellationToken)
        {
            var result = _userTaskRepository.GetById("");
            return Task.FromResult(result.ID);
        }
    }
}
