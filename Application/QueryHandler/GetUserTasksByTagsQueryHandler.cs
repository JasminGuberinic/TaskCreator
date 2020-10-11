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
    public class GetUserTasksByTagsQueryHandler : IRequestHandler<GetUserTasksByTagsQuery, List<UserTask>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUserTaskRepository _userTaskRepository;

        public GetUserTasksByTagsQueryHandler(ITagRepository tagRepository, IUserTaskRepository userTaskRepository)
        {
            _tagRepository = tagRepository;
            _userTaskRepository = userTaskRepository;
        }

        public Task<List<UserTask>> Handle(GetUserTasksByTagsQuery request, CancellationToken cancellationToken)
        {
            var resultTags = _tagRepository.GetByIds(request.TagIDs);
            var resultTasks = _userTaskRepository.GetByTags(resultTags);

            return Task.FromResult(resultTasks);
        }
    }
}
