using Control_usuarios_desactivados.modelos;
using Control_usuarios_desactivados.servicios;
using GenFu;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados_test.Servicios
{
    class controlExcelServicioTest
    {
        [Test]
        public void filtrarPorRangoFechasReturnAbogadosFiltrados()
        {
            var abogadosDesactivados = A.ListOf<AbogadoDesactivado>();
            List<AbogadoDesactivado> listaAbogadosAProbar = new List<AbogadoDesactivado>();
            for (int i = 0; i < 4; i++)
            {
                listaAbogadosAProbar.Add(abogadosDesactivados[i]);
            }
            listaAbogadosAProbar[0].FechaDesactivacion = "1/04/2018";
            listaAbogadosAProbar[1].FechaDesactivacion = "10/04/2018";
            listaAbogadosAProbar[2].FechaDesactivacion = "20/04/2018";
            listaAbogadosAProbar[3].FechaDesactivacion = "25/04/2018";
            ControlAbogadoExcelServicio controlAbogadoExcelServicio = new ControlAbogadoExcelServicio();
            List<AbogadoDesactivado> listaAbogadosRespuesta = new List<AbogadoDesactivado>();
            listaAbogadosRespuesta = controlAbogadoExcelServicio.filtrarPorRangoFechas(listaAbogadosAProbar, "9/04/2018", "21/04/2018");

            Assert.AreEqual(2, listaAbogadosRespuesta.Count);
        }
        [Test]
        public void filtrarPorRangoFechasReturnAbogadosCompletos()
        {
            var abogadosDesactivados = A.ListOf<AbogadoDesactivado>();
            List<AbogadoDesactivado> listaAbogadosAProbar = new List<AbogadoDesactivado>();
            for (int i = 0; i < 4; i++)
            {
                listaAbogadosAProbar.Add(abogadosDesactivados[i]);
            }
            listaAbogadosAProbar[0].FechaDesactivacion = "10/04/2018";
            listaAbogadosAProbar[1].FechaDesactivacion = "12/04/2018";
            listaAbogadosAProbar[2].FechaDesactivacion = "13/04/2018";
            listaAbogadosAProbar[3].FechaDesactivacion = "14/04/2018";
            ControlAbogadoExcelServicio controlAbogadoExcelServicio = new ControlAbogadoExcelServicio();
            List<AbogadoDesactivado> listaAbogadosRespuesta = new List<AbogadoDesactivado>();
            listaAbogadosRespuesta = controlAbogadoExcelServicio.filtrarPorRangoFechas(listaAbogadosAProbar, "9/04/2018", "21/04/2018");

            Assert.AreEqual(4, listaAbogadosRespuesta.Count);
        }

        [Test]
        public void camcularTiempoDesactivadoTest()
        {
            ControlAbogadoExcelServicio controlAbogadoExcelServicio = new ControlAbogadoExcelServicio();
            string result = controlAbogadoExcelServicio.camcularTiempoDesactivado("10/04/2018", "24/04/2018");
            Assert.AreEqual("14 dias", result);
        }
        [Test]
        public void camcularTiempoDesactivadoReturnNoHaSidoActivadoTest()
        {
            ControlAbogadoExcelServicio controlAbogadoExcelServicio = new ControlAbogadoExcelServicio();
            string result = controlAbogadoExcelServicio.camcularTiempoDesactivado("10/04/2018", "0000/00/00");
            Assert.AreEqual("No ha sido activado", result);
        }
    }
}
