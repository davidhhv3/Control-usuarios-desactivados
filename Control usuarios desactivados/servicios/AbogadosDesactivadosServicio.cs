using Control_usuarios_desactivados.modelos;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control_usuarios_desactivados.servicios
{
    public class AbogadosDesactivadosServicio
    {
        private readonly IMongoCollection<AbogadoDesactivado> _bdSgpDesactivados;
        private readonly IMongoCollection<AbogadoDesactivado> _bdSgpReactivados;
        private readonly IMongoCollection<Abogado> _bdMonolegalAbogados;
        public AbogadosDesactivadosServicio()
        {

            var client = new MongoClient("mongodb://monito:M1c43l4T13n3UnC0ch3#@3.23.228.28:27017");


            var databaseSgp = client.GetDatabase("SGP");
            this._bdSgpDesactivados = databaseSgp.GetCollection<AbogadoDesactivado>("Desactivados");
            this._bdSgpReactivados = databaseSgp.GetCollection<AbogadoDesactivado>("Reactivados");

            var databaseMonolegal = client.GetDatabase("Monolegal");
            this._bdMonolegalAbogados = databaseMonolegal.GetCollection<Abogado>("Abogados");
        }

        public AbogadoDesactivado[] InsertarAbogados(AbogadoDesactivado[] abogados)
        {
            this._bdSgpDesactivados.InsertMany(abogados);
            return abogados;
        }
        public List<AbogadoDesactivado> obtenerAbogados()
        {
            List<AbogadoDesactivado> abogadosDesactivados = this._bdSgpDesactivados.Find(d => true).ToList();
            return abogadosDesactivados;
        }
        public List<AbogadoDesactivado> buscarAbogadosCampoActivoFalseBdSgp()
        {
            List<AbogadoDesactivado> abogados = this._bdSgpDesactivados.Find(d => d.Reactivado == false).ToList();
            return abogados;
        }
        public AbogadoDesactivado obtenerAbogadoPorID(string idAbogado)
        {
            return this._bdSgpDesactivados.Find<AbogadoDesactivado>(ab => ab.IdAbogado == idAbogado).FirstOrDefault();
        }
        public void modificarAbogado(string idAbogado, AbogadoDesactivado abogado)
        {
            this._bdSgpDesactivados.ReplaceOne(d => d.IdAbogado == idAbogado, abogado);
        }

        public List<AbogadoDesactivado> InsertarAbogadosCollecionReactivados(List<AbogadoDesactivado> abogados)
        {
            _bdSgpReactivados.InsertMany(abogados);
            return null;
        }
        public void modificarAbogadoPorId_Particular(string idAbogado, AbogadoDesactivado abogado)
        {
            this._bdSgpDesactivados.ReplaceOne(d => d.Id_particular == idAbogado, abogado);
        }
        public int ObtenerCantidadDeUnIdContenidoEnBdDesactivados(string IdAbogado)
        {
            List<AbogadoDesactivado> abogadosDesactivados = this._bdSgpDesactivados.Find(d => d.IdAbogado == IdAbogado).ToList();
            return abogadosDesactivados.Count;
        }
        public List<AbogadoDesactivado> obtenerAbogadosConIdEnComun(string IdAbogado)
        {
            List<AbogadoDesactivado> abogadosDesactivados = this._bdSgpDesactivados.Find(d => d.IdAbogado == IdAbogado).ToList();
            return abogadosDesactivados;
        }
    }
}
