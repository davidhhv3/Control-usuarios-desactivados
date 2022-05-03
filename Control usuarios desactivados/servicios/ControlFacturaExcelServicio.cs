using Control_usuarios_desactivados.modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados.servicios
{
    public class ControlFacturaExcelServicio
    {
        AbogadosServicio abogadoServicio;
        public ControlFacturaExcelServicio()
        {
            this.abogadoServicio = new AbogadosServicio();
        }
        List<Factura> facturasDelAbogado;

        public int obtenerCantidadFacturas(string idAbogado)
        {
            this.facturasDelAbogado = this.abogadoServicio.obtenerFacturasPorIdAbogado(idAbogado);

            if (facturasDelAbogado == null)
            {
                return 0;
            }
            int numeroFacturas = facturasDelAbogado.Count;
            return numeroFacturas;
        }
        public string obtenerNumeroUltimaFactura(int cantidadFacturas)
        {
            string NumeroUltimaFactura;
            if (this.facturasDelAbogado == null)
            {
                return "No tiene facturas";
            }
            if (cantidadFacturas == 0)
            {
                return "No tiene facturas";
            }
            else
            {
                NumeroUltimaFactura = this.facturasDelAbogado[cantidadFacturas - 1].Codigo;
            }

            return NumeroUltimaFactura;
        }
        public string obtenerFechaPrimerFactura()
        {
            if (this.facturasDelAbogado.Count == 0)
            {
                return "No tiene facturas";
            }
            string fechaPrimerFactura = this.facturasDelAbogado[0].FechaCreacion.ToString();
            if (fechaPrimerFactura == null)
            {
                return "No tiene facturas";
            }

            return fechaPrimerFactura;
        }
        public string obtenerAntiguedad(int cantidadFacturas)
        {
            if (this.facturasDelAbogado.Count == 0)
            {
                return "No tiene facturas";
            }
            DateTime fechaPrimeraFactura = this.facturasDelAbogado[0].FechaCreacion;
            DateTime fechaultimaFactura = this.facturasDelAbogado[cantidadFacturas - 1].FechaCreacion;
            TimeSpan diasDiferencia = fechaultimaFactura.Subtract(fechaPrimeraFactura);
            string diasDeDiferencia = diasDiferencia.Days.ToString() + " dias";
            return diasDeDiferencia;
        }
        public string ValorUltimaFactura(int cantidadFacturas)
        {
            string valorultimaFactura;
            if (this.facturasDelAbogado == null)
            {
                return "No tiene facturas";
            }
            if (cantidadFacturas == 0)
            {
                return "No tiene facturas";
            }
            else
            {
                valorultimaFactura = this.facturasDelAbogado[cantidadFacturas - 1].SubTotal;
            }

            return valorultimaFactura;
        }
    }
}
