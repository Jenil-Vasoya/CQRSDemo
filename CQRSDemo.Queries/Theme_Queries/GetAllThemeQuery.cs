using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Queries.Theme_Queries
{
    public class GetAllThemeQuery : IRequest<List<MissionTheme>>
    {
    }
}
