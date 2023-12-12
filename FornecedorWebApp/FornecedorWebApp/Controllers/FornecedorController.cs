using FornecedorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FornecedorWebApp.Controllers
{
    public class FornecedorController : ApiController
    {
        // GET: api/Fornecedor
        public IEnumerable<Fornecedor> Get()
        {
            Fornecedor fornecedor = new Fornecedor();

            return fornecedor.ListarFornecedor();
        }

        // GET: api/Fornecedor/5
        public Fornecedor Get(int id)
        {
            Fornecedor fornecedor = new Fornecedor();

            return fornecedor.ListarFornecedor().Where(x => x.id == id).FirstOrDefault();
        }

        // POST: api/Fornecedor
        public List<Fornecedor> Post(Fornecedor fornecedor)
        {
            Fornecedor _fornecedor = new Fornecedor();

            _fornecedor.Inserir(fornecedor);

            return _fornecedor.ListarFornecedor();
        }

        // PUT: api/Fornecedor/5
        public Fornecedor Put(int id, [FromBody]Fornecedor fornecedor)
        {
            Fornecedor _fornecedor = new Fornecedor();

            return _fornecedor.Atualizar(id, fornecedor);
        }

        // DELETE: api/Fornecedor/5
        public void Delete(int id)
        {
            Fornecedor _fornecedor = new Fornecedor();

            _fornecedor.Deletar(id);
        }
    }
}
