using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.User_Commands
{
    public class AddUserDataCommand : IRequest<UserAdd>
    {
       public UserAdd user { get; set; }
       public AddUserDataCommand(UserAdd _user)
        {
            user = _user;
        }


        public class AddUserDataHandler : IRequestHandler<AddUserDataCommand, UserAdd>
        {

            private readonly IUserRepository _userRepository;

            public AddUserDataHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }


            public async Task<UserAdd> Handle(AddUserDataCommand query, CancellationToken cancellationToken)
            {
                return await _userRepository.AddUserData(query.user);
            }
        }

    }
}
