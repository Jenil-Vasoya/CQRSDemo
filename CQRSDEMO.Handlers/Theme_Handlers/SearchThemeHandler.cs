using CQRSDemo.Core.Models;
using CQRSDemo.Queries.Theme_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Banner_Handlers
{
    public class SearchThemeHandler : IRequestHandler<SearchThemeQuery, List<MissionTheme>>
    {
        private readonly IThemeRepository _themeRepository;

        public SearchThemeHandler(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
        }
        public async Task<List<MissionTheme>?> Handle(SearchThemeQuery request, CancellationToken cancellationToken)
        {
            return await _themeRepository.SearchTheme(request.Search,request.Page,request.PageSize);
        }
    }
}
