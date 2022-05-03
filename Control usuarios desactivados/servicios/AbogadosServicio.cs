using Control_usuarios_desactivados.modelos;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados.servicios
{
    public class AbogadosServicio
    {
        private readonly IMongoCollection<Abogado> _bdMonolegalAbogados;
        private readonly IMongoCollection<Factura> _bdMonolegalFacturas;
        private readonly IMongoCollection<Proceso> _bdMonolegalProcesos;
        private readonly IMongoCollection<ProcesoTyba> _bdMonolegalProcesosTyba;

        public AbogadosServicio()
        {
            var client = new MongoClient("mongodb://monito:M1c43l4T13n3UnC0ch3#@3.23.228.28:27017");
            var databaseMonolegal = client.GetDatabase("Monolegal");
            this._bdMonolegalAbogados = databaseMonolegal.GetCollection<Abogado>("Abogados");
            this._bdMonolegalFacturas = databaseMonolegal.GetCollection<Factura>("Facturas");
            this._bdMonolegalProcesos = databaseMonolegal.GetCollection<Proceso>("Procesos");
            this._bdMonolegalProcesosTyba = databaseMonolegal.GetCollection<ProcesoTyba>("ProcesosTyba");

        }
        public List<Abogado> obtenerAbogadoPorCampoActivo(string idAbogado, bool activo)////1
        {
            List<Abogado> abogado;
            abogado = this._bdMonolegalAbogados.Find(d => d._id == idAbogado && d.Activo == activo).ToList();
            return abogado;
        }
        public Abogado obtenerAbogadoPorId(string idAbogado)//2
        {
            return this._bdMonolegalAbogados.Find<Abogado>(ab => ab._id == idAbogado).FirstOrDefault();
        }

        public List<Factura> obtenerFacturasPorIdAbogado(string idAbogado)
        {
            List<Factura> facturas;
            facturas = this._bdMonolegalFacturas.Find(d => d.IdAbogado == idAbogado).ToList();
            return facturas;
        }
        public List<Proceso> obtenerProcesosPorIdAbogado(string idAbogado)
        {
            List<Proceso> Procesos;
            Procesos = this._bdMonolegalProcesos.Find(d => d.IdAbogado == idAbogado).ToList();
            return Procesos;
        }
        public List<ProcesoTyba> obtenerProcesosTybaPorIdAbogado(string idAbogado)
        {
            List<ProcesoTyba> ProcesosTyba;
            ProcesosTyba = this._bdMonolegalProcesosTyba.Find(d => d.IdAbogado == idAbogado).ToList();
            return ProcesosTyba;
        }
    }
}
