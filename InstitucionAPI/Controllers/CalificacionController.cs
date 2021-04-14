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
    public class CalificacionController : ControllerBase
    {
        [HttpGet]
        [Route("getall")]
        public JsonResult GetAllCalificaciones()
        {
            IEnumerable<CalificacionTutorium> calificacions;

            using (UnidadDeTrabajo<CalificacionTutorium> unidad = new UnidadDeTrabajo<CalificacionTutorium>(new Ensenanza_VoluntariaContext()))
            {
                calificacions = unidad.genericDAL.GetAll();
            }

            return new JsonResult(calificacions);
        }

        [HttpGet]

        public JsonResult GetCalificacion(int id)
        {
            CalificacionTutorium calificacion;
            using (UnidadDeTrabajo<CalificacionTutorium> unidad = new UnidadDeTrabajo<CalificacionTutorium>(new Ensenanza_VoluntariaContext()))
            {
                calificacion = unidad.genericDAL.Get(id);
            }
            return new JsonResult(calificacion);
        }


        [HttpPost]
        [Route("agregar")]
        public bool AgregarCalificacion(CalificacionTutorium calificacion)
        {

            // Category category = new Category();
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<CalificacionTutorium> unidad = new UnidadDeTrabajo<CalificacionTutorium>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Add(calificacion);
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
        public bool ActualizarCalificacion(CalificacionTutorium calificacion)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<CalificacionTutorium> unidad = new UnidadDeTrabajo<CalificacionTutorium>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Update(calificacion);
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
        public bool EliminarCalificacion(CalificacionTutorium calificacion)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<CalificacionTutorium> unidad = new UnidadDeTrabajo<CalificacionTutorium>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Remove(calificacion);
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
