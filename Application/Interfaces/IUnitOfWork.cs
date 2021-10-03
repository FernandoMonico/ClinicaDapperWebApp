using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IDoctorRepository Doctores { get; }
        IPacienteRepository Pacientes { get; }
    }
}
