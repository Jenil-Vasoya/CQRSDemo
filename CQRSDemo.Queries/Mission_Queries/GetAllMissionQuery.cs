using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Queries.Mission_Queries
{
    public class GetAllMissionQuery : IRequest<List<Mission>>
    {
    }
}
