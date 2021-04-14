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
    public class MaterialController : ControllerBase
    {
        [HttpGet]
        [Route("getall")]
        public JsonResult GetAllMaterials()
        {
            IEnumerable<MaterialTutorium> materials;

            using (UnidadDeTrabajo<MaterialTutorium> unidad = new UnidadDeTrabajo<MaterialTutorium>(new Ensenanza_VoluntariaContext()))
            {
                materials = unidad.genericDAL.GetAll();
            }

            return new JsonResult(materials);
        }

        [HttpGet]

        public JsonResult GetMaterial(int id)
        {
            MaterialTutorium material;
            using (UnidadDeTrabajo<MaterialTutorium> unidad = new UnidadDeTrabajo<MaterialTutorium>(new Ensenanza_VoluntariaContext()))
            {
                material = unidad.genericDAL.Get(id);
            }
            return new JsonResult(material);
        }


        [HttpPost]
        [Route("agregar")]
        public bool AgregarMaterial(MaterialTutorium material)
        {

            // Category category = new Category();
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<MaterialTutorium> unidad = new UnidadDeTrabajo<MaterialTutorium>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Add(material);
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
        public bool ActualizarMaterial(MaterialTutorium material)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<MaterialTutorium> unidad = new UnidadDeTrabajo<MaterialTutorium>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Update(material);
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
        public bool EliminarMaterial(MaterialTutorium material)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<MaterialTutorium> unidad = new UnidadDeTrabajo<MaterialTutorium>(new Ensenanza_VoluntariaContext()))
                {
                    unidad.genericDAL.Remove(material);
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
