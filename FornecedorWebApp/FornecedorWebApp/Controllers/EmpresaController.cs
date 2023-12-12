using FornecedorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FornecedorWebApp.Controllers
{
    public class EmpresaController : ApiController
    {
        // GET: api/Empresa
        public IEnumerable<Empresa> Get()
        {
            Empresa empresa = new Empresa();

            return empresa.ListarEmpresa();
        }

        // GET: api/Empresa/5
        public Empresa Get(int id)
        {
            Empresa empresa = new Empresa();

            return empresa.ListarEmpresa().Where(x => x.id == id).FirstOrDefault();
        }

        // POST: api/Empresa
        public List<Empresa> Post(Empresa empresa)
        {
            Empresa _empresa = new Empresa();
            //List<Empresa> empresas = new List<Empresa>();

            _empresa.Inserir(empresa);

            return _empresa.ListarEmpresa();
        }

        // PUT: api/Empresa/5
        public Empresa Put(int id, [FromBody]Empresa empresa)
        {
            Empresa _empresa = new Empresa();

            return _empresa.Atualizar(id, empresa);
        }

        // DELETE: api/Empresa/5
        public void Delete(int id)
        {
            Empresa _empresa = new Empresa();

            _empresa.Deletar(id);
        }
    }
}
