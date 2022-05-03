using Control_usuarios_desactivados.modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados.servicios
{
    public class ControlDesactivadosServicio
    {
        private AbogadosServicio abogadosServicio;
        private AbogadosDesactivadosServicio abogadosDesactivadosServicio;

        public ControlDesactivadosServicio()
        {
            abogadosServicio = new AbogadosServicio();
            abogadosDesactivadosServicio = new AbogadosDesactivadosServicio();

        }
        public List<Abogado> comprobarCampoActivoBdMonolegal(List<AbogadoDesactivado> abogadosCampoReactivadoFalseBdSgp, bool campoActivo)
        {
            List<Abogado> abogadosLista = new List<Abogado>();

            List<Abogado> abogadosfiltradosPorCampoActivoTrue = new List<Abogado>();
            for (int i = 0; i < abogadosCampoReactivadoFalseBdSgp.Count; i++)
            {
                abogadosLista = this.abogadosServicio.obtenerAbogadoPorCampoActivo(abogadosCampoReactivadoFalseBdSgp[i].IdAbogado, campoActivo);
                if (abogadosLista.Count != 0)
                {
                    abogadosfiltradosPorCampoActivoTrue.Add(abogadosLista[0]);
                }
            }
            return abogadosfiltradosPorCampoActivoTrue;
        }
        public void actualizarBdSgp(List<Abogado> abogadosfiltradosPorCampoActivoTrue, string campo)
        {
            AbogadoDesactivado abogadoDesactivado = new AbogadoDesactivado();
            List<AbogadoDesactivado> listaAbogadosAModificar = new List<AbogadoDesactivado>();
            string FechaActual = DateTime.Now.ToString("dd-MM-yyyy").ToString();
            for (int i = 0; i < abogadosfiltradosPorCampoActivoTrue.Count; i++)
            {
                abogadoDesactivado = this.abogadosDesactivadosServicio.obtenerAbogadoPorID(abogadosfiltradosPorCampoActivoTrue[i]._id);
                listaAbogadosAModificar.Add(abogadoDesactivado);

                if (campo == "FechaConsulta")
                {
                    listaAbogadosAModificar[i].UltimaFechaConsultaReactiva = FechaActual;
                    this.modificarAbogadosConIdRepetido(listaAbogadosAModificar[i], FechaActual, campo);
                }
                if (campo == "Reactivado")
                {
                    listaAbogadosAModificar[i].Reactivado = true;
                    listaAbogadosAModificar[i].FechaReactivado = FechaActual;
                    this.modificarAbogadosConIdRepetido(listaAbogadosAModificar[i],FechaActual,campo);
                }
                this.abogadosDesactivadosServicio.modificarAbogado(listaAbogadosAModificar[i].IdAbogado, listaAbogadosAModificar[i]);

            }
            List<AbogadoDesactivado> listaAbogadosDesactivadosMismoId = new List<AbogadoDesactivado>();

        }
        public void modificarAbogadosConIdRepetido(AbogadoDesactivado AbogadoRepetidoAModificar, string FechaActual,string campo)
        {
            List<AbogadoDesactivado> abogadosConIdEnComunBDSgp = new List<AbogadoDesactivado>();
            int cantidadDeUnIdContenidoEnBdDesactivados;
            cantidadDeUnIdContenidoEnBdDesactivados = this.abogadosDesactivadosServicio.ObtenerCantidadDeUnIdContenidoEnBdDesactivados(AbogadoRepetidoAModificar.IdAbogado);
            if (cantidadDeUnIdContenidoEnBdDesactivados > 1)
            {
                abogadosConIdEnComunBDSgp = this.abogadosDesactivadosServicio.obtenerAbogadosConIdEnComun(AbogadoRepetidoAModificar.IdAbogado);
                for (int j = 0; j < abogadosConIdEnComunBDSgp.Count; j++)
                {
                    if (campo == "FechaConsulta")
                    {
                        abogadosConIdEnComunBDSgp[j].UltimaFechaConsultaReactiva = FechaActual;
                    }
                    if (campo == "Reactivado")
                    {
                        abogadosConIdEnComunBDSgp[j].Reactivado = true;
                        abogadosConIdEnComunBDSgp[j].FechaReactivado = FechaActual;
                    }

                    this.abogadosDesactivadosServicio.modificarAbogadoPorId_Particular(abogadosConIdEnComunBDSgp[j].Id_particular, abogadosConIdEnComunBDSgp[j]);
                }
            }
        }
        public void insertarAbogadoReactivados(List<Abogado> abogadosfiltradosPorCampoActivoTrue)
        {
            List<AbogadoDesactivado> listaAbogadosInsertar = new List<AbogadoDesactivado>();
            for (int i = 0; i < abogadosfiltradosPorCampoActivoTrue.Count; i++)
            {
                string FechaActual = DateTime.Now.ToString("dd-MM-yyyy").ToString();
                AbogadoDesactivado abogadoInsertar = new AbogadoDesactivado();
                abogadoInsertar.IdAbogado = abogadosfiltradosPorCampoActivoTrue[i]._id;
                abogadoInsertar.Email = abogadosfiltradosPorCampoActivoTrue[i].Email;
                AbogadoDesactivado abogadoDesactivado = new AbogadoDesactivado();
                abogadoDesactivado = this.abogadosDesactivadosServicio.obtenerAbogadoPorID(abogadosfiltradosPorCampoActivoTrue[i]._id);
                abogadoInsertar.FechaDesactivacion = abogadoDesactivado.FechaDesactivacion;
                abogadoInsertar.FechaReactivado = FechaActual;
                abogadoInsertar.Reactivado = true;
                abogadoInsertar.UltimaFechaConsultaReactiva = abogadoDesactivado.UltimaFechaConsultaReactiva;
                listaAbogadosInsertar.Add(abogadoInsertar);
            }
            this.abogadosDesactivadosServicio.InsertarAbogadosCollecionReactivados(listaAbogadosInsertar);
        }
    }
}
