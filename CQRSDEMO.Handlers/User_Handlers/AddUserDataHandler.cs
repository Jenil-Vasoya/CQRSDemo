using CQRSDemo.Commands;
using CQRSDemo.Commands.User_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers
{
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
