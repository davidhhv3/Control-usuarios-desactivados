using Control_usuarios_desactivados.modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados.servicios
{
    public class ArchivoServicio
    {
        AbogadosDesactivadosServicio abogadoServicio;
        public ArchivoServicio()
        {
            abogadoServicio = new AbogadosDesactivadosServicio();
        }
        public bool ValidarExtension(string ubicacionArchivo)
        {
            char delimitadorubicacionArchivo = '\\';
            string[] ubicacionArchivoDividido = ubicacionArchivo.Split(delimitadorubicacionArchivo);
            int tamañoArchivo = ubicacionArchivoDividido.Length;
            string nombreArchivo = ubicacionArchivoDividido[tamañoArchivo - 1];
            char delimitadorNombreArchivo = '.';
            string[] nombreArchivoDivididos = nombreArchivo.Split(delimitadorNombreArchivo);
            string ExtensionDelArchivo = nombreArchivoDivididos[1];
            if (ExtensionDelArchivo == "csv")
            {
                return true;
            }
            return false;
        }
        public AbogadoDesactivado[] extraerAbogadosArchivoScv(string ubicacionArchivo)
        {
            AbogadoDesactivado[] abogados = new AbogadoDesactivado[0];
            int n = 0;
            string linea;
            System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacionArchivo);
            archivo.ReadLine();
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(';');
                Array.Resize(ref abogados, abogados.Length + 1);

                abogados[n] = new AbogadoDesactivado();
                abogados[n].IdAbogado = fila[0];
                abogados[n].Email = fila[1];
                abogados[n].FechaDesactivacion = fila[2];
                abogados[n].FechaReactivado = "0000/00/00";
                abogados[n].UltimaFechaConsultaReactiva = "0000/00/00";
                n = n + 1;
            }
            archivo.Close();
            return abogados;
        }
        public void guardarAbogados(AbogadoDesactivado[] abogados)
        {
            this.abogadoServicio.InsertarAbogados(abogados);
        }
    }
}
