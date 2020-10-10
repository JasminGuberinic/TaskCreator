using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, string>
    {
        private readonly ITagRepository _tagRepository;

        public DeleteTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<string> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var tagToDelete = await _tagRepository.DeleteTag(request.Id);
            return request.Id;
        }
    }
}
