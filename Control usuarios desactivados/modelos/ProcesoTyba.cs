using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados.modelos
{
    public class ProcesoTyba
    {
        public string _id { get; set; }

        public string NumProceso { get; set; }

        public string IdActualizacion { get; set; }

        public string IdExpedienteDigital { get; set; }

        public string IdActualizacionAnterior { get; set; }

        public string IdUltimaConsulta { get; set; }

        public string IdUltimaAlteracion { get; set; }

        public string FechaActualizacion { get; set; }

        public string Estado { get; set; }

        public DateTime? FechaRevision { get; set; }

        public DateTime FechaRevisionDate { get; set; }

        public string FechaCreacion { get; set; }

        public DateTime FechaCreacionDate { get; set; }

        public string FechaActualizacionTicks { get; set; }

        public string FechaProximaConsultaTicks { get; set; }

        public DateTime FechaActualizacionDate { get; set; }

        public DateTime FechaProximaConsultaDate { get; set; }

        public string EsNuevo { get; set; }

        public string Abogado { get; set; }

        public string Etiqueta { get; set; }

        public string UbicacionExp { get; set; }

        public string IdAbogado { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Columnas { get; set; }

        public string OrdenarPor { get; set; }

        public string FiltrarPor { get; set; }

        public string Ip { get; set; }

        public bool Automatico { get; set; }

        public string TipoProceso { get; set; }

        public string ClaseProceso { get; set; }

        public string SubClaseProceso { get; set; }

        public string Departamento { get; set; }

        public string Ciudad { get; set; }

        public string Corporacion { get; set; }

        public string Especialidad { get; set; }

        public string Distrito { get; set; }

        public string NumeroDespacho { get; set; }

        public string Despacho { get; set; }

        public string IdMonito { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string CorreoElectronicoExterno { get; set; }

        public string FechaPublicacion { get; set; }

        public DateTime FechaPublicacionDate { get; set; }

        public string FechaProvidencia { get; set; }

        public string FechaProvidenciaDate { get; set; }

        public string FechaFinalizacion { get; set; }

        public DateTime FechaFinalizacionDate { get; set; }

        public string TipoDecision { get; set; }

        public string Observaciones { get; set; }

        public int NumSujetos { get; set; }

        public int NumActuaciones { get; set; }

        public string Demandantes { get; set; }

        public string Demandados { get; set; }

        public string DefensoresPrivados { get; set; }

        public string Termino { get; set; }

        public DateTime TerminoTicksDate { get; set; }

        public string TipoActuacion { get; set; }

        public string FechaActuacion { get; set; }

        public string FechaRegistro { get; set; }

        public string UltimaAnotacion { get; set; }

        public string UltimoComentarioContenido { get; set; }

        public DateTime UltimoComentarioFechaCreacion { get; set; }

        public string UltimoComentarioFechaMostrar { get; set; }

        public string UltimoComentarioNombreAbogado { get; set; }

        public string UltimoComentarioFechaRecordatorio { get; set; }

        public string IdProcesoRama { get; set; }

        public string? IdBoton { get; set; }

        public int CoincidenciasConsultaActual { get; set; }

        public int CoincidenciasConsultaAnterior { get; set; }

        public string[] coincidencias { get; set; }
    }
}
