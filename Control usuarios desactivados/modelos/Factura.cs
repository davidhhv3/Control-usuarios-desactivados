using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados.modelos
{
    public class Factura
    {
        public string _id { get; set; }

        public string Codigo { get; set; }

        public string IdAbogado { get; set; }

        public string Estado { get; set; }

        public bool Pagado { get; set; }

        public DateTime FechaUltimaComunicacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime InicioFactura { get; set; }

        public DateTime FinFactura { get; set; }

        public string PathPdf { get; set; }

        public string SubTotal { get; set; }

        public string RetencionEnFuente { get; set; }

        public string Iva { get; set; }

        public string Total { get; set; }

        public string Token { get; set; }

        public string TransactionId { get; set; }

        public string TransactionCode { get; set; }

        public string TransactionMessage { get; set; }

        public string ReferenciaIndividual { get; set; }

        public string ReferenciaAgrupada { get; set; }

        public string SegundaReferenciaAgrupada { get; set; }

        public DateTime FechaTransaccion { get; set; }

        public bool EsCasoEspecial { get; set; }

        public bool DescuentoVolumen { get; set; }

        public bool DescuentoAntiguedad { get; set; }

        public string IdProcesoCobro { get; set; }
    }
}
