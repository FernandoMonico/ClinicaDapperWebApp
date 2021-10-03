using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDoctorRepository doctorRepository, IPacienteRepository pacienteRepository)
        {
            Doctores = doctorRepository;
            Pacientes = pacienteRepository;
        }

        public IDoctorRepository Doctores { get; }
        public IPacienteRepository Pacientes { get; }
    }
}
