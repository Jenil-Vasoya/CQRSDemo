using CQRSDemo.Core.Models;
using CQRSDemo.Queries.CMS_Queries;
using CQRSDemo.Queries.Story_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRSDemo.Queries.Story_Queries;

namespace CQRSDEMO.Handlers.Story_Handlers
{
    public class GetStoryDataHandler : IRequestHandler<GetStoryDataQuery, Story>
    {
        private readonly IStoryRepository _StoryRepository;

        public GetStoryDataHandler(IStoryRepository StoryRepository)
        {
            _StoryRepository = StoryRepository;
        }
        public async Task<Story> Handle(GetStoryDataQuery request, CancellationToken cancellationToken)
        {
            return await _StoryRepository.GetStory(request.StoryId);
        }
    }
}
