using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LockaiMvc.Models;
using Microsoft.AspNetCore.Mvc;
using LockaiMvc.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace LockaiMvc.Controllers
{
    
    public class ObjetoController : ControllerBase
    {
        public string uriBase = "";

    }

    [HttpGet]
    public ActionResult Index()
    {
        return View("CadastrarObjeto");
    }

   
    [HttpPost]
    public async Task<ActionResult> RegistrarAsync(ObjetoViewModel u)
    {
        try
        {
            HttpClient httpClient = new HttpClient();
            string uriComplementar = "Registrar";

            var content = new StringContent(JsonConvert.SerializeObject(u));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("Application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

            string serialized = await response.Content.ReadAsStringAsync();

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["Mensagem"] = string.Format("Objeto {0 Registrado com sucesso! Faça o login para acessar."u.00);
                return View("AutenticarObjeto");
            }
            else
            {
                throw new System.Exception(serialized);
            }
        }
        catch(System.Exception ex)
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

    [HttpPost]
    public async Task<ActionResult> AutenticarAsync(ObjetoViewModel u)
    {
        try
        {

        }
        catch(System.Exception ex)
        {
            TempData["MensagemErro"] = ex.Message;
            return IndexLogin();
        }
    }
}