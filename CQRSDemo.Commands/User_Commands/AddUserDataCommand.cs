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
    public class AddUserDataCommand : INotification
    {
       public UserAdd user { get; set; }

       public AddUserDataCommand(UserAdd _user)
        {
            user = _user;
        }



        public class AddUserDataHandler : INotificationHandler<AddUserDataCommand>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMediator _mediator;

            public AddUserDataHandler(IUserRepository userRepository, IMediator mediator)
            {
                _userRepository = userRepository;
                _mediator = mediator;
            }

            public async Task Handle(AddUserDataCommand query, CancellationToken cancellationToken)
            {
                long userId = await _userRepository.AddUserData(query.user);
                Console.WriteLine($"User registered: Email - {query.user.Email}");
               await _mediator.Publish(new GetUserDataNotification { UserId = userId });
            }
        }

        //public class AddUserDataHandler : IRequestHandler<AddUserDataCommand>
        //{

        //    private readonly IUserRepository _userRepository;

        //    public AddUserDataHandler(IUserRepository userRepository)
        //    {
        //        _userRepository = userRepository;
        //    }


        //    public async Task Handle(AddUserDataCommand query, CancellationToken cancellationToken)
        //    {
        //         await _userRepository.AddUserData(query.user);
        //    }
        //}

    }
}
