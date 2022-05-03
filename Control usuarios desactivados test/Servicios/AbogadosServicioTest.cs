using Control_usuarios_desactivados.modelos;
using Control_usuarios_desactivados.servicios;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados_test.Servicios
{
    class AbogadosServicioTest
    {
        [Test]
        public void obtenerAbogadoPorCampoActivoReturnAbogado()
        {
            AbogadosServicio abogadosServicio = new AbogadosServicio();
            List<Abogado> abogado;
            abogado = abogadosServicio.obtenerAbogadoPorCampoActivo("12", true);
            Assert.IsNotNull(abogado);
        }
        [Test]
        public void obtenerAbogadoPorCampoActivoReturnANull()
        {
            AbogadosServicio abogadosServicio = new AbogadosServicio();
            List<Abogado> abogado;
            abogado = abogadosServicio.obtenerAbogadoPorCampoActivo(null, true);
            Assert.IsNotNull(abogado);
        }
        [Test]
        public void obtenerAbogadoPorIdReturnAbogado()
        {
            AbogadosServicio abogadosServicio = new AbogadosServicio();
            Abogado abogado = new Abogado();
            abogado = abogadosServicio.obtenerAbogadoPorId("12343");
            Assert.IsNotNull(abogado);
        }

        [Test]
        public void obtenerFacturasPorIdAbogadoReturnAbogado()
        {
            AbogadosServicio abogadosServicio = new AbogadosServicio();
            List<Factura> factura;
            factura = abogadosServicio.obtenerFacturasPorIdAbogado("12344");
            Assert.IsNotNull(factura);
        }
    }
}
