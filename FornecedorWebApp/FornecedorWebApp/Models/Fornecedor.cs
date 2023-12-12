using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace FornecedorWebApp.Models
{
    public class Fornecedor
    {
        public int id { get; set; }
        public string idempresa { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public string cpfcnpj { get; set; }
        public string rg { get; set; }
        public string nasc { get; set; }
        public string telefone { get; set; }
        public string data { get; set; }

        public List<Fornecedor> ListarFornecedor()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Fornecedor.json");
            var json = File.ReadAllText(caminhoArquivo);
            var listaFornecedores = JsonConvert.DeserializeObject<List<Fornecedor>>(json);

            return listaFornecedores;
        }

        public bool ReescreverArquivo(List<Fornecedor> listaFornecedores)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Fornecedor.json");

            var json = JsonConvert.SerializeObject(listaFornecedores, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }

        public Fornecedor Inserir(Fornecedor Fornecedor)
        {
            var listaFornecedores = this.ListarFornecedor();

            var maxId = listaFornecedores.Max(p => p.id);
            Fornecedor.id = maxId + 1;
            listaFornecedores.Add(Fornecedor);

            ReescreverArquivo(listaFornecedores);
            return Fornecedor;
        }

        public Fornecedor Atualizar(int id, Fornecedor Fornecedor)
        {
            var listaFornecedores = this.ListarFornecedor();

            var itemIndex = listaFornecedores.FindIndex(p => p.id == id);
            if (itemIndex >= 0)
            {
                Fornecedor.id = id;
                listaFornecedores[itemIndex] = Fornecedor;
            }
            else
            {
                return null;
            }

            ReescreverArquivo(listaFornecedores);
            return Fornecedor;
        }

        public bool Deletar(int id)
        {
            var listaFornecedores = this.ListarFornecedor();

            var itemIndex = listaFornecedores.FindIndex(p => p.id == id);
            if (itemIndex >= 0)
            {
                listaFornecedores.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            ReescreverArquivo(listaFornecedores);
            return true;
        }
    }
}