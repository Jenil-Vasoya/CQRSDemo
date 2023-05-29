using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Queries.CMS_Queries
{
    public class GetCMSDataQuery : IRequest<Cmspage>
    {
        public long CMSId { get; set; }
    }
}
