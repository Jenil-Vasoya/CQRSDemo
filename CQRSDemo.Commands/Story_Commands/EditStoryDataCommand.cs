using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Story_Commands
{
    public class EditStoryDataCommand : IRequest<Story>
    {
        public Story Story { get; set; }

        public EditStoryDataCommand(Story _Story)
        {
            Story = _Story;
        }
    }
}
