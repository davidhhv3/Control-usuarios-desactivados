using Control_usuarios_desactivados.servicios;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados_test.Servicios
{
    class ArchivoServicioTest
    {
        [Test]
        public void ValidarExtensionReturnTrue()
        {
            var archivoServicioTest = new ArchivoServicio();
            bool resultado = archivoServicioTest.ValidarExtension("D:\\abogados.csv");
            Assert.AreEqual(true, resultado);
        }

        [Test]
        public void ValidarExtensionReturnFalse()
        {
            var archivoServicioTest = new ArchivoServicio();
            bool resultado = archivoServicioTest.ValidarExtension("D:\\abogados.txt");
            Assert.AreEqual(false, resultado);
        }
    }
}
