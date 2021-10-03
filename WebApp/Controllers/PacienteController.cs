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
    public class PacienteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PacienteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Pacientes.GetAllAsync();
            var pacienteDtoList = result.Select(x => _mapper.Map<PacienteDto>(x));
            return View(pacienteDtoList);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PacienteDto pacienteDto) {
            if (ModelState.IsValid) {
                var paciente = _mapper.Map<Paciente>(pacienteDto);
                var result = await _unitOfWork.Pacientes.AddAsync(paciente);
                return RedirectToAction("Index");
            }
            return View(pacienteDto);
        }

        public async Task<IActionResult> Edit(int id) {
            var result = await _unitOfWork.Pacientes.GetByIdAsync(id);
            var pacienteDto = _mapper.Map<PacienteDto>(result);
            return View(pacienteDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PacienteDto pacienteDto) {
            if (ModelState.IsValid) {
                var paciente = _mapper.Map<Paciente>(pacienteDto);
                var result = await _unitOfWork.Pacientes.UpdateAsync(paciente);
                return RedirectToAction("Index");
            }
            return View(pacienteDto);
        }

        public async Task<IActionResult> Delete(int id) {
            var result = await _unitOfWork.Pacientes.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
