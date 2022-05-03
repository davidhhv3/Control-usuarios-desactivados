using Control_usuarios_desactivados.modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados.servicios
{
    public class ControlProcesosExcelServicio
    {
        List<Proceso> procesosDelAbogado;
        List<ProcesoTyba> procesosTybaDelAbogado;
        AbogadosServicio abogadoServicio;

        public ControlProcesosExcelServicio()
        {
            this.abogadoServicio = new AbogadosServicio();
        }
        public int obtenerCantidadProcesos(string idAbogado)
        {
            this.procesosDelAbogado = this.abogadoServicio.obtenerProcesosPorIdAbogado(idAbogado);
            if (procesosDelAbogado == null)
            {
                return 0;
            }
            int numeroDeProcesos = procesosDelAbogado.Count;
            return numeroDeProcesos;
        }
        public int obtenerCantidadProcesosTyba(string idAbogado)
        {
            this.procesosTybaDelAbogado = this.abogadoServicio.obtenerProcesosTybaPorIdAbogado(idAbogado);
            if (procesosTybaDelAbogado == null)
            {
                return 0;
            }
            int numeroDeProcesos = procesosTybaDelAbogado.Count;
            return numeroDeProcesos;
        }
    }
}
