using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados.modelos
{
    public  class Proceso
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

        public string FechaRevision { get; set; }

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

        public string Ip { get; set; }

        public bool Automatico { get; set; }

        public string Despacho { get; set; }

        public string IdMonito { get; set; }

        public string FechaTermino { get; set; }

        public string Ponente { get; set; }

        public string Ubicacion { get; set; }

        public string ContenidoRadicacion { get; set; }

        public string Ciudad { get; set; }

        public string NombreCiudad { get; set; }

        public string Corporacion { get; set; }

        public string NombreCorporacion { get; set; }

        public string HibernateClass { get; set; }

        public string FechaTerminoTicks { get; set; }

        public DateTime FechaTerminoTicksDate { get; set; }

        public string Email { get; set; }

        public string Tipo { get; set; }

        public string Clase { get; set; }

        public string Demandantes { get; set; }

        public string Demandados { get; set; }

        public string Recurso { get; set; }

        public string NumActuaciones { get; set; }

        public string FechaUltimaActuacion { get; set; }

        public string UltimaActuacion { get; set; }

        public string UltimaAnotacion { get; set; }

        public string NumActuacionesAnterior { get; set; }

        public string EmailDemo { get; set; }

        public bool TieneAmanyos { get; set; }

        public bool AmanyosNotificados { get; set; }

        public int IndiceAmanyo { get; set; }

        public string UltimoComentario { get; set; }

        public bool ContinuarRegistro { get; set; }

        public int UsuarioQueLoRegistra { get; set; }
    }
}
