using Control_usuarios_desactivados.servicios;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados_test.Servicios
{
    class ControlProcesosExcelServicioTest
    {
        [Test]
        public void obtenerCantidadProcesos_returnCantidadProcesos()
        {
            ControlProcesosExcelServicio controlProcesosExcelServicio = new ControlProcesosExcelServicio();
            int cantidadProcesos = controlProcesosExcelServicio.obtenerCantidadProcesos("2127");
            Assert.AreEqual(382, cantidadProcesos);
        }
        [Test]
        public void obtenerCantidadProcesos_returCero()
        {
            ControlProcesosExcelServicio controlProcesosExcelServicio = new ControlProcesosExcelServicio();
            int cantidadProcesos = controlProcesosExcelServicio.obtenerCantidadProcesos("xxxxxxx");
            Assert.AreEqual(0, cantidadProcesos);
        }
        [Test]
        public void obtenerCantidadProcesosTyba_returnCantidadProcesosTyba()
        {
            ControlProcesosExcelServicio controlProcesosExcelServicio = new ControlProcesosExcelServicio();
            int cantidadProcesosTyba = controlProcesosExcelServicio.obtenerCantidadProcesosTyba("2127");
            Assert.AreEqual(229, cantidadProcesosTyba);
        }
        [Test]
        public void obtenerCantidadProcesosTyba_returnCero()
        {
            ControlProcesosExcelServicio controlProcesosExcelServicio = new ControlProcesosExcelServicio();
            int cantidadProcesosTyba = controlProcesosExcelServicio.obtenerCantidadProcesosTyba("xxxx");
            Assert.AreEqual(0, cantidadProcesosTyba);
        }
    }
}
