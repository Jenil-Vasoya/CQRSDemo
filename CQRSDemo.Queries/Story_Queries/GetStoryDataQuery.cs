using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Queries.Story_Queries
{
    public class GetStoryDataQuery : IRequest<Story>
    {
        public long StoryId { get; set; }
    }
}
