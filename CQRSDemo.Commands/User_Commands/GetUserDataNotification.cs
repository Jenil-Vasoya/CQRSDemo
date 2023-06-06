using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.User_Commands
{
    public class GetUserDataNotification : INotification
    {
        public long UserId { get; set; }
    }

    public class GetUserDataHandlerNotification : INotificationHandler<GetUserDataNotification>
    {
        private readonly IUserRepository _userRepository;

        public GetUserDataHandlerNotification(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(GetUserDataNotification notification, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserData(notification.UserId);
            Console.WriteLine($"User: UserId - {user.UserId}, Name - {user.FirstName}, Email - {user.Email}");

        }
    }

}
