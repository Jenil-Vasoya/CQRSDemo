using CQRSDemo.Core.Models;
using CQRSDemo.Queries.CMS_Queries;
using CQRSDemo.Queries.Theme_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Theme_Handlers
{
    public class GetThemeDataHandler : IRequestHandler<GetThemeDataQuery, MissionTheme>
    {
        private readonly IThemeRepository _themeRepository;

        public GetThemeDataHandler(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
        }
        public async Task<MissionTheme> Handle(GetThemeDataQuery request, CancellationToken cancellationToken)
        {
            return await _themeRepository.GetTheme(request.ThemeId);
        }
    }
}
