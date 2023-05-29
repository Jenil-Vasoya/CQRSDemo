using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Queries.User_Queries
{
    public class GetUserDataQuery : IRequest<User>
    {
        public long UserId { get; set; }
    }
}
