using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LockaiMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LockaiMvc.Controllers
{
    public class ObjetoController : Controller
    {
        public string uriBase = "http://guigao.somee.com/TccApi/Objeto/";

       [HttpGet]
        public async Task<ActionResult> IndexAsync()
        {
            try
            {
                string uriComplementar = "GetAll";
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(uriBase + uriComplementar);

                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<ObjetoViewModel> ConsultarObjeto = await Task.Run(() =>
                    JsonConvert.DeserializeObject<List<ObjetoViewModel>>(serialized)); 
                    return View("ConsultarObjeto", ConsultarObjeto);
                }
                else
                {
                    throw new System.Exception($"Erro ao carregar objetos: {serialized}");
                }
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
/*
        [HttpPost]
        public async Task<ActionResult> RegistrarAsync(ObjetoViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string uriComplementar = "/Registrar";

                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["Mensagem"] = string.Format("Objeto {0} registrado com sucesso! Faça o login para acessar.", u.Nome);
                    return View("AutenticarObjeto");
                }
                else
                {
                    throw new System.Exception(serialized);
                }
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult IndexLogin()
        {
            return View("AutenticarObjeto");
        }

/*
        [HttpPost]
        public async Task<ActionResult> AutenticarAsync(ObjetoViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string uriComplementar = "/Autenticar";

                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["Mensagem"] = "Objeto autenticado com sucesso!";
                    return RedirectToAction("ListarObjetos");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    TempData["MensagemErro"] = "Credenciais inválidas. Por favor, tente novamente.";
                    return View("AutenticarObjeto");
                }
                else
                {
                    throw new System.Exception(serialized);
                }
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return IndexLogin();
            }
        }
        */

        [HttpGet]
        public async Task<ActionResult> ListarObjetos()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(uriBase);

                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<ObjetoViewModel> objetos = JsonConvert.DeserializeObject<List<ObjetoViewModel>>(serialized);
                    return View("ListarObjetos", objetos);
                }
                else
                {
                    throw new System.Exception($"Erro ao carregar objetos: {serialized}");
                }
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("IndexLogin");
            }
        }
    }
}