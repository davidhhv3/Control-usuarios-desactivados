using Control_usuarios_desactivados.servicios;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados_test.Servicios
{
    class ControlFacturaExcelServicioTest
    {
        [Test]
        public void obtenerCantidadFacturasReturnCantidadFacturas()
        {
            ControlFacturaExcelServicio controlFacturaExcelServicio = new ControlFacturaExcelServicio();
            int numeroFacturasRespuesta = controlFacturaExcelServicio.obtenerCantidadFacturas("2127");
            Assert.AreEqual(88, numeroFacturasRespuesta);
        }
        [Test]
        public void obtenerCantidadFacturasReturnCantidadCero()
        {
            ControlFacturaExcelServicio controlFacturaExcelServicio = new ControlFacturaExcelServicio();
            int numeroFacturasRespuesta = controlFacturaExcelServicio.obtenerCantidadFacturas("kdkdkkdkds");
            Assert.AreEqual(0, numeroFacturasRespuesta);
        }
        [Test]
        public void obtenerNumeroUltimaFacturaReturnNumero_UltimaFactura()
        {
            ControlFacturaExcelServicio controlFacturaExcelServicio = new ControlFacturaExcelServicio();
            int cantidadFacturas = controlFacturaExcelServicio.obtenerCantidadFacturas("2127");
            string numeroUltimaFactura = controlFacturaExcelServicio.obtenerNumeroUltimaFactura(cantidadFacturas);
            Assert.AreEqual("FE-22363", numeroUltimaFactura);
        }
        [Test]
        public void obtenerNumeroUltimaFacturaReturnNumero_NoTieneFacturas()
        {
            ControlFacturaExcelServicio controlFacturaExcelServicio = new ControlFacturaExcelServicio();
            int cantidadFacturas = controlFacturaExcelServicio.obtenerCantidadFacturas("3220");
            string numeroUltimaFactura = controlFacturaExcelServicio.obtenerNumeroUltimaFactura(cantidadFacturas);
            Assert.AreEqual("No tiene facturas", numeroUltimaFactura);
        }
        [Test]
        public void obtenerFechaPrimerFactura_ReturnFecha()
        {
            ControlFacturaExcelServicio controlFacturaExcelServicio = new ControlFacturaExcelServicio();
            controlFacturaExcelServicio.obtenerCantidadFacturas("2127");
            string resultado = controlFacturaExcelServicio.obtenerFechaPrimerFactura();

            Assert.AreEqual("25/05/2015 2:32:43 p. m.", resultado);
        }
        [Test]
        public void obtenerFechaPrimerFactura_ReturnNoTieneFacturas()
        {
            ControlFacturaExcelServicio controlFacturaExcelServicio = new ControlFacturaExcelServicio();
            controlFacturaExcelServicio.obtenerCantidadFacturas("3220");
            string resultado = controlFacturaExcelServicio.obtenerFechaPrimerFactura();
            Assert.AreEqual("No tiene facturas", resultado);
        }
        [Test]
        public void obtenerAntiguedad_returnAntiguedad()
        {
            ControlFacturaExcelServicio controlFacturaExcelServicio = new ControlFacturaExcelServicio();
            int cantidadFacturas = controlFacturaExcelServicio.obtenerCantidadFacturas("2127");
            string antiguedad = controlFacturaExcelServicio.obtenerAntiguedad(cantidadFacturas);
            Assert.AreEqual("2507 dias", antiguedad);
        }
        [Test]
        public void obtenerAntiguedad_returnNotieneFacturas()
        {
            ControlFacturaExcelServicio controlFacturaExcelServicio = new ControlFacturaExcelServicio();
            int cantidadFacturas = controlFacturaExcelServicio.obtenerCantidadFacturas("3220");
            string antiguedad = controlFacturaExcelServicio.obtenerAntiguedad(cantidadFacturas);
            Assert.AreEqual("No tiene facturas", antiguedad);
        }
        [Test]
        public void ValorUltimaFactura_ReturnValorUltimaFactura()
        {
            ControlFacturaExcelServicio controlFacturaExcelServicio = new ControlFacturaExcelServicio();
            int cantidadFacturas = controlFacturaExcelServicio.obtenerCantidadFacturas("2127");
            string valorultimaFactura = controlFacturaExcelServicio.ValorUltimaFactura(cantidadFacturas);
            Assert.AreEqual("297911.80000", valorultimaFactura);
        }
        [Test]
        public void ValorUltimaFactura_ReturnNoTieneFacturas()
        {
            ControlFacturaExcelServicio controlFacturaExcelServicio = new ControlFacturaExcelServicio();
            int cantidadFacturas = controlFacturaExcelServicio.obtenerCantidadFacturas("3220");
            string valorultimaFactura = controlFacturaExcelServicio.ValorUltimaFactura(cantidadFacturas);
            Assert.AreEqual("No tiene facturas", valorultimaFactura);
        }
    }
}
