using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DTOs;

namespace WebApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Doctores.GetAllAsync();
            var doctorDtoList = result.AsEnumerable().Select(x => _mapper.Map<DoctorDto>(x)).ToList();
            return View(doctorDtoList);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorDto doctorDto) {
            if (ModelState.IsValid)
            {
                var doctor = _mapper.Map<Doctor>(doctorDto);
                var result = await _unitOfWork.Doctores.AddAsync(doctor);
                return RedirectToAction("Index");
            }
            return View(doctorDto);
        }

        public async Task<IActionResult> Delete(int id) {
            var result = await _unitOfWork.Doctores.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id) {
            var result = await _unitOfWork.Doctores.GetByIdAsync(id);
            var doctorDto = _mapper.Map<DoctorDto>(result);
            return View(doctorDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DoctorDto doctorDto) {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            var result = await _unitOfWork.Doctores.UpdateAsync(doctor);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateList() {
            var doctorList = new List<Doctor>
            {
                new Doctor { Nombre = "Nombre 1", Apellido = "Apellido 1", Especialidad = "Especialidad 1" },
                new Doctor { Nombre = "Nombre 2", Apellido = "Apellido 2", Especialidad = "Especialidad 2" },
                new Doctor { Nombre = "Nombre 3", Apellido = "Apellido 3", Especialidad = "Especialidad 3" }
            };
            var result = await _unitOfWork.Doctores.AddListAsync(doctorList);
            return RedirectToAction("Index");
        }
    }
}
