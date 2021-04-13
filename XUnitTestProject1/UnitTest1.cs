using System;
using Xunit;
using BackEnd.DAL;
using BackEnd.Entities;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Institucion institucion = new Institucion
            {
                Nombre = "Fidel Chavez Murillo",
            };

            using (UnidadDeTrabajo<Institucion> unidad = new UnidadDeTrabajo<Institucion>(new Ensenanza_VoluntariaContext()))
            {
                bool result = unidad.genericDAL.Add(institucion);
                result = unidad.Complete();
                Assert.True(result, "Es verdadero");
            }
        }
    }
}
