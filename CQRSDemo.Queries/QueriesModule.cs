using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Queries
{
    public static class QueriesModule
    {
        public static IServiceCollection AddUseCasesModule(this IServiceCollection services)
        {
            services = services ?? throw new ArgumentNullException(nameof(services));
            var thisAssembly = typeof(QueriesModule).Assembly;

            services
                .AddMediatR(thisAssembly);
            
            return services;
        }
    }
}
