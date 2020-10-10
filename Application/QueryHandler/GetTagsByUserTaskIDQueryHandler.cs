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
    public class GetTagsByUserTaskIDQueryHandler : IRequestHandler<GetTagsByUserTaskIDQuery, List<Tag>>
    {
        private readonly ITagRepository _tagRepository;

        public GetTagsByUserTaskIDQueryHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public Task<List<Tag>> Handle(GetTagsByUserTaskIDQuery request, CancellationToken cancellationToken)
        {
            var resultTags = _tagRepository.GetByUserTaskId(request.UserTaskID);
            return Task.FromResult(resultTags);
        }
    }
}
