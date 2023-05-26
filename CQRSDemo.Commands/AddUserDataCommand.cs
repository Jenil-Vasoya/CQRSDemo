using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands
{
    public class AddUserDataCommand : IRequest<UserAdd>
    {
       public UserAdd user { get; set; }
       public AddUserDataCommand(UserAdd _user)
        {
            user = _user;
        }

    }
}
