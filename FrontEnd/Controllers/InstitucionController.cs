using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class InstitucionController : Controller
    {
        private InstitucionViewModel convertir(Institucion ins)
        {
            return new InstitucionViewModel 
            { 
                IdInstitucion = ins.IdInstitucion,
                Nombre = ins.Nombre,
                TutoriaCursos = ins.TutoriaCursos,
            };
        }

        public IActionResult Index()
        {
            List<Institucion> institucionsBackEnd;

            using (UnidadDeTrabajo<Institucion> unidad = new UnidadDeTrabajo<Institucion>(new Ensenanza_VoluntariaContext()))
            {
                institucionsBackEnd = unidad.genericDAL.GetAll().ToList();
            }
            List<InstitucionViewModel> institucions = new List<InstitucionViewModel>();
            InstitucionViewModel institucion = new InstitucionViewModel();

            foreach (var item in institucionsBackEnd) {
                institucion = this.convertir(item);
                institucions.Add(institucion);
            }

            return View(institucions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Institucion institucion)
        {
            using (UnidadDeTrabajo<Institucion> unidad = new UnidadDeTrabajo<Institucion>(new Ensenanza_VoluntariaContext()))
            {
                unidad.genericDAL.Add(institucion);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}
