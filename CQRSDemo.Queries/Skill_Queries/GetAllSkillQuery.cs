using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Queries.Skill_Queries
{
    public class GetAllSkillQuery : IRequest<List<Skill>>
    {
    }
}
