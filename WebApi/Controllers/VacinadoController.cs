using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class VacinadoController : ApiController
    {
        // GET: api/vacinado
        public List<Vacinado> Get()
        {
            Vacinado vacinado = new Vacinado();
            return vacinado.ListaVacinados();
        }

        // GET: api/vacinado/5
        public Vacinado Get(int id)
        {
            Vacinado vacinado = new Vacinado();
            return vacinado.ListaVacinados().Where(x => x.Sid ==id).FirstOrDefault();
        }

        // GET: api/vacinado/5
        public Vacinado Get(string nome)
        {
            Vacinado vacinado = new Vacinado();
            return vacinado.ListaVacinados().Where(x => x.Snome == nome).FirstOrDefault();
        }


        // POST: api/vacinado
        public List<Vacinado> Post(Vacinado vacinado)
        {
            Vacinado _vacinado = new Vacinado();
            _vacinado.Inserir(vacinado);
            return _vacinado.ListaVacinados();

        }

        // PUT: api/vacinado/5
        public List<Vacinado> Put(int id, Vacinado vacinado)
        {
            Vacinado _vacinado = new Vacinado();
            _vacinado.Atualizar(id, vacinado);
            return _vacinado.ListaVacinados();

        }

        // DELETE: api/vacinado/5
        public void Delete(int id)
        {
            Vacinado _vacinado = new Vacinado();
            _vacinado.Deletar(id);
           
        }
    }
}
