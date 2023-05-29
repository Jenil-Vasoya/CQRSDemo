using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Story_Commands
{
    public class DeleteStoryDataCommand : IRequest<bool>
    {
        public long StoryId { get; set; }
    }
}
