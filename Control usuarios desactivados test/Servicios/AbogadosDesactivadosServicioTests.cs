using Control_usuarios_desactivados.modelos;
using Control_usuarios_desactivados.servicios;
using GenFu;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados_test.Servicios
{
    class AbogadosDesactivadosServicioTests
    {
        [Test]
        public void InsertarAbogadosReturnAbogados()
        {
            var abogadosDesactivados = A.ListOf<AbogadoDesactivado>();

            AbogadoDesactivado[] abogadosDesactivadosArrray = new AbogadoDesactivado[abogadosDesactivados.Count];
            for (int i = 0; i < abogadosDesactivados.Count; i++)
            {
                abogadosDesactivadosArrray[i] = abogadosDesactivados[i];
                abogadosDesactivadosArrray[i].Id_particular = null;

            }
            AbogadosDesactivadosServicio abogadosDesactivadosServicio = new AbogadosDesactivadosServicio();

            Assert.IsNotNull(abogadosDesactivadosServicio.InsertarAbogados(abogadosDesactivadosArrray));
        }
    }
}
