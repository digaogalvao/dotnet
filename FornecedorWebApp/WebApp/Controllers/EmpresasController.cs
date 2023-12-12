using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmpresasController : Controller
    {
        // GET: Empresas
        public ActionResult Index()
        {
            IEnumerable<EmpresaViewModel> empresas = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64554/api/");

                //HTTP GET
                var responseTask = client.GetAsync("Empresa");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<EmpresaViewModel>>();
                    readTask.Wait();
                    empresas = readTask.Result;
                }
                else
                {
                    empresas = Enumerable.Empty<EmpresaViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(empresas);
            };
        }

        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(EmpresaViewModel empresa)
        {
            if (empresa == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64554/api/");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<EmpresaViewModel>("Empresa", empresa);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return View(empresa);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaViewModel empresa = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64554/api/Empresa");

                //HTTP GET
                var responseTask = client.GetAsync("?id=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EmpresaViewModel>();
                    readTask.Wait();
                    empresa = readTask.Result;
                }
            }
            return View(empresa);
        }

        [HttpPost]
        public ActionResult Edit(EmpresaViewModel empresa)
        {
            if (empresa == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64554/api/");
                //HTTP PUT
                var putTask = client.PostAsJsonAsync<EmpresaViewModel>("Empresa", empresa);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(empresa);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaViewModel empresa = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64554/api/");
                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Empresa/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(empresa);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaViewModel empresa = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64554/api/Empresa");

                //HTTP GET
                var responseTask = client.GetAsync("?id=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EmpresaViewModel>();
                    readTask.Wait();
                    empresa = readTask.Result;
                }
            }
            return View(empresa);
        }
    }
}