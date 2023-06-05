using CQRSDemo.Core.Models;
using CQRSDemo.Repository.DTOs;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Queries.User_Queries
{
    public class GetAllUserQuery : IRequest<IEnumerable<User>>
    {
        public Paging _paging { get; set; }
        public GetAllUserQuery(Paging paging)
        {
            _paging = paging;
        }

        public class Handler : IRequestHandler<GetAllUserQuery, IEnumerable<User>>
        {
            private readonly IUserRepository _userRepository;

            public Handler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<IEnumerable<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                return await _userRepository.GetAllUser(request._paging);
            }
        }
    }


}
