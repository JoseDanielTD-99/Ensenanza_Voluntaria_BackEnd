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
    public class CursoController : ControllerBase
    {
        [HttpGet]
        [Route("getall")]
        public JsonResult GetAllCursos()
        {
            IEnumerable<Curso> cursos;

            using (UnidadDeTrabajo<Curso> unidad = new UnidadDeTrabajo<Curso>(new Ensenanza_VoluntariaContext()))
            {
                cursos = unidad.genericDAL.GetAll();
            }

            return new JsonResult(cursos);
        }

        [HttpGet]

        public JsonResult GetCurso(int id)
        {
            Curso curso;
            using (UnidadDeTrabajo<Curso> unidad = new UnidadDeTrabajo<Curso>(new Ensenanza_VoluntariaContext()))
            {
                curso = unidad.genericDAL.Get(id);
            }
            return new JsonResult(curso);
        }


        [HttpPost]
        [Route("agregar")]
        public bool AgregarCurso(Curso curso)
        {

            // Category category = new Category();
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Curso> unidad = new UnidadDeTrabajo<Curso>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Add(curso);
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
        public bool ActualizarCurso(Curso curso)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Curso> unidad = new UnidadDeTrabajo<Curso>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Update(curso);
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
        public bool EliminarCurso(Curso curso)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Curso> unidad = new UnidadDeTrabajo<Curso>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Remove(curso);
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
