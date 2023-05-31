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
    public class EditUserDataCommand : IRequest<UserAdd>
    {
        public UserAdd user { get; set; }

        public EditUserDataCommand(UserAdd _user)
        {
            user = _user;
        }

        public class EditUserDataHandler : IRequestHandler<EditUserDataCommand, UserAdd>
        {   

            private readonly IUserRepository _userRepository;

            public EditUserDataHandler(IUserRepository userRepository)
            {   
                _userRepository = userRepository;
            }


            public async Task<UserAdd> Handle(EditUserDataCommand query, CancellationToken cancellationToken)
            {
                return await _userRepository.EditUserData(query.user);
            }
        }

    }
}
