using Microsoft.Extensions.DependencyInjection;
using Ordering.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BL
{
    public static class BLServiceRegistration
    {
        public static IServiceCollection AddBLServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderBL, OrderBL>();
            return services;
        }
    }
}
