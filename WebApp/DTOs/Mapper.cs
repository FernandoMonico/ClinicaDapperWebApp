using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.DTOs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Doctor, DoctorDto>()
                .ForMember(x => x.NombreCompleto, y => y.MapFrom(z => $"{z.Nombre} {z.Apellido}"));
            CreateMap<DoctorDto, Doctor>();
        }
    }
}
