using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace FornecedorWebApp.Models
{
    public class Empresa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
        public int cnpj { get; set; }

        public List<Empresa> ListarEmpresa()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Empresa.json");
            var json = File.ReadAllText(caminhoArquivo);
            var listaEmpresas = JsonConvert.DeserializeObject<List<Empresa>>(json);

            /*Empresas empresa = new Empresas();
            empresa.id = 1;
            empresa.nome = "xpto";
            empresa.uf = "RJ";
            empresa.cnpj = 123456789;

            List<Empresas> listaEmpresas = new List<Empresas>();

            listaEmpresas.Add(empresa);*/

            return listaEmpresas;
        }

        public bool ReescreverArquivo(List<Empresa> listaEmpresas)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Empresa.json");

            var json = JsonConvert.SerializeObject(listaEmpresas, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }

        public Empresa Inserir(Empresa Empresa)
        {
            var listaEmpresas = this.ListarEmpresa();

            var maxId = listaEmpresas.Max(p => p.id);
            Empresa.id = maxId + 1;
            listaEmpresas.Add(Empresa);

            ReescreverArquivo(listaEmpresas);
            return Empresa;
        }

        public Empresa Atualizar(int id, Empresa Empresa)
        {
            var listaEmpresas = this.ListarEmpresa();

            var itemIndex = listaEmpresas.FindIndex(p => p.id == id);
            if (itemIndex >= 0)
            {
                Empresa.id = id;
                listaEmpresas[itemIndex] = Empresa;
            }
            else
            {
                return null;
            }

            ReescreverArquivo(listaEmpresas);
            return Empresa;
        }

        public bool Deletar(int id)
        {
            var listaEmpresas = this.ListarEmpresa();

            var itemIndex = listaEmpresas.FindIndex(p => p.id == id);
            if (itemIndex >= 0)
            {
                listaEmpresas.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            ReescreverArquivo(listaEmpresas);
            return true;
        }
    }
}