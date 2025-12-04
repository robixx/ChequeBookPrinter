using ChequeBook.Application;
using ChequeBook.Application.Interface;
using ChequeBook.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ChequeBook.Infrastructure.Utility
{
    public static class ServiceInjection
    {
        public static void InjectService(this IServiceCollection services)
        {
           
            services.AddScoped<IMenu, MenuServices>();
            services.AddScoped<IBankInfo, BankService>();
            

        }
    }
}
