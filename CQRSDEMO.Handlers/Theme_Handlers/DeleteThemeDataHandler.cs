using CQRSDemo.Commands.Theme_Commands;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Theme_Handlers
{
    public class DeleteThemeDataHandler : IRequestHandler<DeleteThemeDataCommand, bool>
    {
        private readonly IThemeRepository _themeRepository;

        public DeleteThemeDataHandler(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
        }

        public async Task<bool> Handle(DeleteThemeDataCommand request, CancellationToken cancellationToken)
        {
            return await _themeRepository.DeleteThemeData(request.ThemeId);
        }
    }
}
