using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDoctorRepository doctorRepository)
        {
            Doctores = doctorRepository;
        }

        public IDoctorRepository Doctores { get; }
    }
}
