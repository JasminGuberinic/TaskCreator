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
    class GetUserTasksByTagsNamesQueryHandler : IRequestHandler<GetUserTasksByTagsNamesQuery, List<UserTask>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUserTaskRepository _userTaskRepository;

        public GetUserTasksByTagsNamesQueryHandler(ITagRepository tagRepository, IUserTaskRepository userTaskRepository)
        {
            _tagRepository = tagRepository;
            _userTaskRepository = userTaskRepository;
        }

        public Task<List<UserTask>> Handle(GetUserTasksByTagsNamesQuery request, CancellationToken cancellationToken)
        {
            var resultUserTaskIds = _tagRepository.GetUserTaskIdsByTagNames(request.TagNames);
            var resultUserTask= _userTaskRepository.GeUserTaskstByIds(resultUserTaskIds);

            return Task.FromResult(resultUserTask);
        }
    }
}
