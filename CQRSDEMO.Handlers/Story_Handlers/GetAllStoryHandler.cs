using CQRSDemo.Core.Models;
using CQRSDemo.Queries.Story_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Story_Handlers
{
    public class GetAllStoryHandler : IRequestHandler<GetAllStoryQuery, List<Story>>
    {
        private readonly IStoryRepository _skillRepository;

        public GetAllStoryHandler(IStoryRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
       
        public async Task<List<Story>> Handle(GetAllStoryQuery query, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetAllStory();
        }
    }
}
