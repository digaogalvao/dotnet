using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class FornecedorViewModel
    {
        [Display(Name = "Código")]
        public int id { get; set; }
        [Display(Name = "Cod.Empresa")]
        public string idempresa { get; set; }
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "Tipo")]
        public string tipo { get; set; }
        [Display(Name = "CPF/CNPJ")]
        public string cpfcnpj { get; set; }
        [Display(Name = "RG")]
        public string rg { get; set; }
        [Display(Name = "Data Nasc.")]
        public string nasc { get; set; }
        [Display(Name = "Telefone")]
        public string telefone { get; set; }
        [Display(Name = "Data")]
        public string data { get; set; }
    }
}