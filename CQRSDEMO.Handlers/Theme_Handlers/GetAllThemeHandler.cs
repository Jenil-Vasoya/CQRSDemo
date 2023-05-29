using CQRSDemo.Core.Models;
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
    public class GetAllThemeHandler : IRequestHandler<GetAllThemeQuery, List<MissionTheme>>
    {
        private readonly IThemeRepository _themeRepository;

        public GetAllThemeHandler(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
        }
       
        public async Task<List<MissionTheme>> Handle(GetAllThemeQuery query, CancellationToken cancellationToken)
        {
            return await _themeRepository.GetAllTheme();
        }
    }
}
