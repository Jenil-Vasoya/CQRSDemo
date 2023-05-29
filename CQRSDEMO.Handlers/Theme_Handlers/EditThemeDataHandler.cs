using CQRSDemo.Commands.Theme_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Theme_Handlers
{
    public class EditThemeDataHandler : IRequestHandler<EditThemeDataCommand, MissionTheme>
    {
        private readonly IThemeRepository _themeRepository;

        public EditThemeDataHandler(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
        }

        public async Task<MissionTheme> Handle(EditThemeDataCommand request, CancellationToken cancellationToken)
        {
           return await _themeRepository.EditThemeData(request.theme);
        }
    }
}
