using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucionController : ControllerBase
    {
        [HttpGet]
        [Route("getall")]
        public JsonResult GetAllDistritos()
        {
            IEnumerable<Institucion> institucions;

            using (UnidadDeTrabajo<Institucion> unidad = new UnidadDeTrabajo<Institucion>(new Ensenanza_VoluntariaContext()))
            {
                institucions = unidad.genericDAL.GetAll();
            }

            return new JsonResult(institucions);
        }

        [HttpGet]

        public JsonResult GetDistrito(int id)
        {
            Institucion institucion;
            using (UnidadDeTrabajo<Institucion> unidad = new UnidadDeTrabajo<Institucion>(new Ensenanza_VoluntariaContext()))
            {
                institucion = unidad.genericDAL.Get(id);
            }
            return new JsonResult(institucion);
        }

        
        [HttpPost]
        [Route("agregar")]
        public bool AgregarDistrito(Institucion institucion)
        {

            // Category category = new Category();
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Institucion> unidad = new UnidadDeTrabajo<Institucion>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Add(institucion);
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
        public bool Actualizar(Institucion institucion)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Institucion> unidad = new UnidadDeTrabajo<Institucion>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Update(institucion);
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
        public bool Eliminar(Institucion institucion)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Institucion> unidad = new UnidadDeTrabajo<Institucion>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Remove(institucion);
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
