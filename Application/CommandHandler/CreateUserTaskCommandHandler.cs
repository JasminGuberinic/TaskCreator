using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class CreateUserTaskCommandHandler : IRequestHandler<CreateUserTaskCommand, Guid>
    {
        private readonly IUserTaskRepository _userTaskRepository;
        public CreateUserTaskCommandHandler(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }

        public async Task<Guid> Handle(CreateUserTaskCommand request, CancellationToken cancellationToken)
        {
            return await _userTaskRepository.CreateUserTask(request.Name, request.Description);
        }
    }
}
