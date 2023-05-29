using CQRSDemo.Commands.Story_Commands;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Story_Handlers
{
    public class DeleteStoryDataHandler : IRequestHandler<DeleteStoryDataCommand, bool>
    {
        private readonly IStoryRepository _StoryRepository;

        public DeleteStoryDataHandler(IStoryRepository StoryRepository)
        {
            _StoryRepository = StoryRepository;
        }

        public async Task<bool> Handle(DeleteStoryDataCommand request, CancellationToken cancellationToken)
        {
            return await _StoryRepository.DeleteStoryData(request.StoryId);
        }
    }
}
