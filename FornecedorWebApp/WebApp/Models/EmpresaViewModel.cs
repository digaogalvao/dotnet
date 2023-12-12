using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class EmpresaViewModel
    {
        [Display(Name = "Código")]
        public int id { get; set; }
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "UF")]
        public string uf { get; set; }
        [Display(Name = "CNPJ")]
        public int cnpj { get; set; }
    }
}