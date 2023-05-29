using CQRSDemo.Commands.Story_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Story_Handlers
{
    public class EditStoryDataHandler : IRequestHandler<EditStoryDataCommand, Story>
    {
        private readonly IStoryRepository _StoryRepository;

        public EditStoryDataHandler(IStoryRepository StoryRepository)
        {
            _StoryRepository = StoryRepository;
        }

        public async Task<Story> Handle(EditStoryDataCommand request, CancellationToken cancellationToken)
        {
           return await _StoryRepository.EditStoryData(request.Story);
        }
    }
}
