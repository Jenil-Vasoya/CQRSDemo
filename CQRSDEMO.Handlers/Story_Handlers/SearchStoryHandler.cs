using CQRSDemo.Core.Models;
using CQRSDemo.Queries.Story_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Banner_Handlers
{
    public class SearchStoryHandler : IRequestHandler<SearchStoryQuery, List<Story>>
    {
        private readonly IStoryRepository _storyRepository;

        public SearchStoryHandler(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }
        public async Task<List<Story>?> Handle(SearchStoryQuery request, CancellationToken cancellationToken)
        {
            return await _storyRepository.SearchStory(request.Search,request.Page,request.PageSize);
        }
    }
}
