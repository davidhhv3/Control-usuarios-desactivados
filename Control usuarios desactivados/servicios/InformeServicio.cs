using Control_usuarios_desactivados.modelos;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados.servicios
{
    public  class InformeServicio
    {
        StringBuilder csvcontent;
        AbogadosServicio abogadoServicio;
        AbogadosDesactivadosServicio abogadosDesactivadosServicio;
        ControlFacturaExcelServicio controlFacturasExcelServicio;
        ControlProcesosExcelServicio controlProcesosExcelServicio;
        ControlAbogadoExcelServicio controlAbogadoExcelServicio;
        System.Data.DataTable dt;

        public InformeServicio()
        {
            this.csvcontent = new StringBuilder();
            this.abogadoServicio = new AbogadosServicio();
            this.abogadosDesactivadosServicio = new AbogadosDesactivadosServicio();
            this.controlFacturasExcelServicio = new ControlFacturaExcelServicio();
            this.controlProcesosExcelServicio = new ControlProcesosExcelServicio();
            this.controlAbogadoExcelServicio = new ControlAbogadoExcelServicio();
            this.dt = new System.Data.DataTable();
        }
        public List<AbogadoDesactivado> preguntaFiltrarPorFecha(List<AbogadoDesactivado> abogadosDesactivados)
        {
            Console.WriteLine("¿Quieres filtrar los resultados por fecha de desactivación?");
            Console.WriteLine("Si / No");
            String respuestaFiltrarResultados = Console.ReadLine();
            List<AbogadoDesactivado> abogadosDesactivadosFiltrados = new List<AbogadoDesactivado>();
            if (respuestaFiltrarResultados == "Si" || respuestaFiltrarResultados == "si")
            {
                Console.WriteLine("Seleccione el rango de la fecha inferior");
                string? rangoFechaInferior = Console.ReadLine();
                Console.WriteLine("Seleccione el rango de la fecha superior");
                string? rangoFechaSuperior = Console.ReadLine();
                abogadosDesactivadosFiltrados = this.controlAbogadoExcelServicio.filtrarPorRangoFechas(abogadosDesactivados, rangoFechaInferior, rangoFechaSuperior);
                return abogadosDesactivadosFiltrados;
            }
            return abogadosDesactivados;

        }
        public string PreguntaArchivoConFechas()
        {
            Console.WriteLine("¿Quiere dejar sin fechas el archivo?");
            Console.WriteLine("Si / No");
            String respuesta = "";
            respuesta = Console.ReadLine();
            return respuesta;
        }
        public void crearInforme(List<AbogadoDesactivado> abogadosDesactivados, string respuestaSiNo)
        {
            string pathFile = @"../../../Informe.xlsx";
            SLDocument oSLDocument = new SLDocument();
            //System.Data.DataTable dt = new System.Data.DataTable();
            //columnas
            this.dt.Columns.Add("Id Desactivacion", typeof(string));
            this.dt.Columns.Add("Id Abogado", typeof(string));
            this.dt.Columns.Add("Email", typeof(string));
            this.dt.Columns.Add("Fecha Desactivacion", typeof(string));
            this.dt.Columns.Add("Fecha Reactivacion", typeof(string));
            this.dt.Columns.Add("Fecha Ultima Consulta Reactivacion", typeof(string));
            this.dt.Columns.Add("Cedula", typeof(string));
            this.dt.Columns.Add("Nombre", typeof(string));
            this.dt.Columns.Add("Numero de facturas", typeof(int));
            this.dt.Columns.Add("Numero ultima factura", typeof(string));
            this.dt.Columns.Add("Valor ultima factura", typeof(string));
            this.dt.Columns.Add("Numero de procesos Rama", typeof(int));
            this.dt.Columns.Add("Numero de procesos Tyba", typeof(int));
            this.dt.Columns.Add("Fecha primera factura:", typeof(string));
            this.dt.Columns.Add("Antigüedad", typeof(string));
            this.dt.Columns.Add("Moroso", typeof(string));
            this.dt.Columns.Add("Cuanto duro desactivado", typeof(string));


            List<Factura> facturasDelAbogado;
            //registros , rows
            for (int i = 0; i < abogadosDesactivados.Count; i++)
            {
                Abogado abogado = new Abogado();
                abogado = this.abogadoServicio.obtenerAbogadoPorId(abogadosDesactivados[i].IdAbogado);

                int canntidadFacturasAbogado = this.controlFacturasExcelServicio.obtenerCantidadFacturas(abogadosDesactivados[i].IdAbogado);
                string numeroUltimaFactura = this.controlFacturasExcelServicio.obtenerNumeroUltimaFactura(canntidadFacturasAbogado);
                string ValorUltimaFactura = this.controlFacturasExcelServicio.ValorUltimaFactura(canntidadFacturasAbogado);
                int cantidadProcesosAbogado = this.controlProcesosExcelServicio.obtenerCantidadProcesos(abogadosDesactivados[i].IdAbogado);
                int cabtidadProcesosTyba = this.controlProcesosExcelServicio.obtenerCantidadProcesosTyba(abogadosDesactivados[i].IdAbogado);
                string FechaPrimeraFactura = this.controlFacturasExcelServicio.obtenerFechaPrimerFactura();
                string antiguedad = this.controlFacturasExcelServicio.obtenerAntiguedad(canntidadFacturasAbogado);
                string moroso = this.controlAbogadoExcelServicio.AbogadoMoroso(abogadosDesactivados[i].IdAbogado);
                string diasDesactivado = this.controlAbogadoExcelServicio.camcularTiempoDesactivado(abogadosDesactivados[i].FechaDesactivacion, abogadosDesactivados[i].FechaReactivado);
                this.dt.Rows.Add(abogadosDesactivados[i].Id_particular
                            , abogadosDesactivados[i].IdAbogado
                            , abogadosDesactivados[i].Email
                            , abogadosDesactivados[i].FechaDesactivacion
                            , abogadosDesactivados[i].FechaReactivado
                            , abogadosDesactivados[i].UltimaFechaConsultaReactiva
                            , abogado.Nit
                            , abogado.Nombre
                            , canntidadFacturasAbogado, numeroUltimaFactura,
                            ValorUltimaFactura
                            , cantidadProcesosAbogado
                            , cabtidadProcesosTyba
                            , FechaPrimeraFactura
                            , antiguedad
                            , moroso
                            , diasDesactivado);
            }
            if (respuestaSiNo == "Si" || respuestaSiNo == "si")
            {
                this.eliminarColumnas();
            }
            oSLDocument.ImportDataTable(1, 1, this.dt, true);
            oSLDocument.SaveAs(pathFile);
        }
        public void eliminarColumnas()
        {
            this.dt.Columns.Remove(dt.Columns[3]);
            this.dt.Columns.Remove(dt.Columns[3]);
            this.dt.Columns.Remove(dt.Columns[3]);
            this.dt.Columns.Remove(dt.Columns[10]);
        }
    }
}
