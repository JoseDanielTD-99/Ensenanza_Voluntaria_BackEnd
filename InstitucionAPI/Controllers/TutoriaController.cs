using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutoriaController : ControllerBase
    {

        [HttpGet]
        [Route("getall")]
        public JsonResult GetAllTutorias()
        {
            IEnumerable<TutoriaCurso> tutorias;

            using (UnidadDeTrabajo<TutoriaCurso> unidad = new UnidadDeTrabajo<TutoriaCurso>(new Ensenanza_VoluntariaContext()))
            {
                tutorias = unidad.genericDAL.GetAll();
            }

            return new JsonResult(tutorias);
        }

        [HttpGet]

        public JsonResult GetTutoria(int id)
        {
            TutoriaCurso tutoria;
            using (UnidadDeTrabajo<TutoriaCurso> unidad = new UnidadDeTrabajo<TutoriaCurso>(new Ensenanza_VoluntariaContext()))
            {
                tutoria = unidad.genericDAL.Get(id);
            }
            return new JsonResult(tutoria);
        }


        [HttpPost]
        [Route("agregar")]
        public bool AgregarTutoria(TutoriaCurso tutoria)
        {

            // Category category = new Category();
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TutoriaCurso> unidad = new UnidadDeTrabajo<TutoriaCurso>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Add(tutoria);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                result = false;
            }

            return result;

        }



        [HttpPost]
        [Route("actualizar")]
        public bool ActualizarTutoria(TutoriaCurso tutoria)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TutoriaCurso> unidad = new BackEnd.DAL.UnidadDeTrabajo<TutoriaCurso>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Update(tutoria);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }


        [HttpPost]
        [Route("eliminar")]
        public bool EliminarTutoria(TutoriaCurso tutoria)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TutoriaCurso> unidad = new UnidadDeTrabajo<TutoriaCurso>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Remove(tutoria);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                result = false;
            }

            return result;

        }
    }
}
