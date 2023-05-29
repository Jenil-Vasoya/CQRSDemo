using CQRSDemo.Data.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.User_Commands
{
    public class EditUserDataCommand : IRequest<UserAdd>
    {
        public UserAdd user { get; set; }

        public EditUserDataCommand(UserAdd _user)
        {
            user = _user;
        }

    }
}
