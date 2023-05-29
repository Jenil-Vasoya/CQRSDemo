using CQRSDemo.Commands;
using CQRSDemo.Commands.User_Commands;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers
{
    public class DeleteUserDataHandler : IRequestHandler<DeleteUserDataCommand, bool>
    {

        private readonly IUserRepository _userRepository;

        public DeleteUserDataHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<bool> Handle(DeleteUserDataCommand query, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteUserData(query.UserId);
        }

    }
}
