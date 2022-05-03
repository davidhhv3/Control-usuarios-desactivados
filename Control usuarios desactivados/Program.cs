using Control_usuarios_desactivados.modelos;
using Control_usuarios_desactivados.servicios;
using System;
using System.Collections.Generic;

namespace Control_usuarios_desactivados
{
    class Program
    {
        static void Main(string[] args)
        {
            ArchivoServicio archivoServicio = new ArchivoServicio();
            AbogadosDesactivadosServicio abogadosDesactivadosServicio = new AbogadosDesactivadosServicio();
            ControlDesactivadosServicio controlDesactivadosServicio = new ControlDesactivadosServicio();

            //Carga y Guardar usuarios desactivados
            string ubicacionArchivo = "..\\..\\..\\Abogados Desactivados.csv";
            bool archivoValido = archivoServicio.ValidarExtension(ubicacionArchivo);
            if (archivoValido == true)
            {
                AbogadoDesactivado[] abogados = new AbogadoDesactivado[0];
                abogados = archivoServicio.extraerAbogadosArchivoScv(ubicacionArchivo);
                archivoServicio.guardarAbogados(abogados);
            }

            //Controla los usuarios desactivados
            List<AbogadoDesactivado> AbogadosCampoActivoFalseBdSgp = abogadosDesactivadosServicio.buscarAbogadosCampoActivoFalseBdSgp();///1
            List<Abogado> abogadosfiltradosPorCampoActivoTrue = controlDesactivadosServicio.comprobarCampoActivoBdMonolegal(AbogadosCampoActivoFalseBdSgp, true);
            List<Abogado> abogadosfiltradosPorCampoActivoFalse = controlDesactivadosServicio.comprobarCampoActivoBdMonolegal(AbogadosCampoActivoFalseBdSgp, false);
            controlDesactivadosServicio.actualizarBdSgp(abogadosfiltradosPorCampoActivoFalse, "FechaConsulta");
            controlDesactivadosServicio.insertarAbogadoReactivados(abogadosfiltradosPorCampoActivoTrue);
            controlDesactivadosServicio.actualizarBdSgp(abogadosfiltradosPorCampoActivoTrue, "Reactivado");

            //Informe control desactivados
            InformeServicio informeServicio = new InformeServicio();
            List<AbogadoDesactivado> abogadosDesactivados = abogadosDesactivadosServicio.obtenerAbogados();
            List<AbogadoDesactivado> abogadosDesactivadosList = new List<AbogadoDesactivado>();
            abogadosDesactivadosList = informeServicio.preguntaFiltrarPorFecha(abogadosDesactivados);
            string archivoConFechas = informeServicio.PreguntaArchivoConFechas();
            informeServicio.crearInforme(abogadosDesactivadosList, archivoConFechas);
        }
    }
}
