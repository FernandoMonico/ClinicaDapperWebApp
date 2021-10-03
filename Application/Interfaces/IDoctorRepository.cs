using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<int> AddListAsync(List<Doctor> doctorList);
    }
}
