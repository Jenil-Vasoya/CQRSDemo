using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Queries.Application_Queries
{
    public class GetApplicationDataQuery : IRequest<MissionApplication>
    {
        public long ApplicationId { get; set; }
    }
}
