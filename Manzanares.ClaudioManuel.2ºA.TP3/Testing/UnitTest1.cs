using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                Gimnasio myGim = new Gimnasio();
                Alumno miAlumno = new Alumno(4, "Miguel", "Hernandez", "92264456",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.Pilates,
                Alumno.EEstadoCuenta.AlDia);
                myGim += miAlumno;
                Assert.Fail("Sin excepcion para NacionalidadInvalidaException");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                Gimnasio myGim = new Gimnasio();
                Alumno miAlumnoNulo = null;
                myGim += miAlumnoNulo;
                Assert.Fail("Sin excepcion para NullReferenceException");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NullReferenceException));
            }
        }
    }
}
