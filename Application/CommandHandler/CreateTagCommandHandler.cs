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
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Guid>
    {
        private readonly ITagRepository _tagRepository;

        public CreateTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<Guid> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            if(NameCheckService.IsTagNameValid(request.TagName))
                return await _tagRepository.CreateUserTag(request.UserTaskID, request.TagName);
            throw new InvalidNameException("Each tag must be at least 3 characters long and must consist of alphabetical lowercase letters");
        }
    }
}
