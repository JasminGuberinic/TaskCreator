﻿using MediatR;
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
            return await _tagRepository.CreateUserTag(request.UserTaskID, request.TagName);
        }
    }
}
