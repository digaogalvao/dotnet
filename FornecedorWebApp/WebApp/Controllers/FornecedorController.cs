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
    public class FornecedorController : Controller
    {
        // GET: Fornecedor
        public ActionResult Index()
        {
            IEnumerable<FornecedorViewModel> fornecedores = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64554/api/");

                //HTTP GET
                var responseTask = client.GetAsync("Fornecedor");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<FornecedorViewModel>>();
                    readTask.Wait();
                    fornecedores = readTask.Result;
                }
                else
                {
                    fornecedores = Enumerable.Empty<FornecedorViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(fornecedores);
            };
        }

        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(FornecedorViewModel fornecedor)
        {
            if (fornecedor == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64554/api/");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<FornecedorViewModel>("Fornecedor", fornecedor);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return View(fornecedor);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedor = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64554/api/Fornecedor");

                //HTTP GET
                var responseTask = client.GetAsync("?id=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<FornecedorViewModel>();
                    readTask.Wait();
                    fornecedor = readTask.Result;
                }
            }
            return View(fornecedor);
        }

        [HttpPost]
        public ActionResult Edit(FornecedorViewModel fornecedor)
        {
            if (fornecedor == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64554/api/");
                //HTTP PUT
                var putTask = client.PostAsJsonAsync<FornecedorViewModel>("Fornecedor", fornecedor);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(fornecedor);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedor = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64554/api/");
                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Fornecedor/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(fornecedor);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedor = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64554/api/Fornecedor");

                //HTTP GET
                var responseTask = client.GetAsync("?id=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<FornecedorViewModel>();
                    readTask.Wait();
                    fornecedor = readTask.Result;
                }
            }
            return View(fornecedor);
        }
    }
}