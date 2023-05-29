using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Queries.Banner_Queries
{
    public class GetAllBannerQuery : IRequest<List<Banner>>
    {
    }
}
