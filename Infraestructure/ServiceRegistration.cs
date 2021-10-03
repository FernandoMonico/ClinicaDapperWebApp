using Application.Interfaces;
using Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure
{
    public static class ServiceRegistration
    {
        public static void AddInfraestructure(this IServiceCollection services) {
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
