using Control_usuarios_desactivados.modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados.servicios
{
    public class ControlAbogadoExcelServicio
    {
        AbogadosDesactivadosServicio abogadosDesactivadosServicio;
        public ControlAbogadoExcelServicio()
        {
            this.abogadosDesactivadosServicio = new AbogadosDesactivadosServicio();
        }
        public List<AbogadoDesactivado> filtrarPorRangoFechas(List<AbogadoDesactivado> abogadosDesactivados, string? rangoFechaInferior, string? rangoFechaSuperior)
        {
            DateTime rangoFechaInferiorDt = Convert.ToDateTime(rangoFechaInferior);
            DateTime rangoFechaSuperiorDt = Convert.ToDateTime(rangoFechaSuperior);
            List<AbogadoDesactivado> abogadosFiltradosPorFecha = new List<AbogadoDesactivado>();
            for (int i = 0; i < abogadosDesactivados.Count; i++)
            {
                DateTime fechaDeDesactivacion = Convert.ToDateTime(abogadosDesactivados[i].FechaDesactivacion);
                if ((fechaDeDesactivacion >= rangoFechaInferiorDt) && (fechaDeDesactivacion <= rangoFechaSuperiorDt))
                {
                    abogadosFiltradosPorFecha.Add(abogadosDesactivados[i]);
                }
            }
            if (abogadosFiltradosPorFecha.Count > 0)
            {
                return abogadosFiltradosPorFecha;
            }
            return abogadosDesactivados;
        }
        public string camcularTiempoDesactivado(string fechaDesactivacion, string fechaReactivacion)
        {
            if (fechaReactivacion == "0000/00/00")
            {
                return "No ha sido activado";
            }
            DateTime fechaDesactivacionDt = Convert.ToDateTime(fechaDesactivacion);
            DateTime fechaReactivacionDt = Convert.ToDateTime(fechaReactivacion);
            TimeSpan diasDiferencia = fechaReactivacionDt.Subtract(fechaDesactivacionDt);
            string diasDeDiferencia = diasDiferencia.Days.ToString() + " dias";
            return diasDeDiferencia;
        }
        public string AbogadoMoroso(string idAbogado)
        {
            int CantidadDeUnIdContenidoEnBdDesactivados = this.abogadosDesactivadosServicio.ObtenerCantidadDeUnIdContenidoEnBdDesactivados(idAbogado);
            if(CantidadDeUnIdContenidoEnBdDesactivados > 2)
            {
                return "Moroso";
            }
            return "No es moroso";
        }
    }
}
