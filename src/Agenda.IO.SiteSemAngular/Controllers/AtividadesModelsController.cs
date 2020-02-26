using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agenda.IO.Model;
using Agenda.IO.Business;
using Microsoft.AspNetCore.Http;
using Agenda.IO.SiteSemAngular.Models;
using System.Diagnostics;

namespace Agenda.IO.SiteSemAngular.Controllers
{
    public class AtividadesModelsController : Controller
    {
        AtividadeBusiness _atividadesBusiness = new AtividadeBusiness();

        public IActionResult Index()
        {
            var atividade = _atividadesBusiness.Obter().OrderBy(p => p.DataInicio);
            return View(atividade);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            AtividadesModel atividade = new AtividadesModel
            {
                Nome = collection["Nome"].ToString(),
                Descricao = collection["Descricao"].ToString(),
                DataInicio = string.IsNullOrEmpty(collection["DataInicio"]) ? (DateTime?)null : Convert.ToDateTime(collection["DataInicio"]),
                DataFim = string.IsNullOrEmpty(collection["DataFim"]) ? (DateTime?)null : Convert.ToDateTime(collection["DataFim"]),
            };
            _atividadesBusiness.Salvar(atividade);
            return View();
        }

        public ActionResult Edit(int id)
        {
            // TODO : Validadr se a atividade não tem a data de inicio menor que a de fim
            var atividade = _atividadesBusiness.Obter(id);
            if (atividade == null) return NotFound();
            _atividadesBusiness.Alterar(atividade);
            return View(atividade);
        }

        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                AtividadesModel atividade = new AtividadesModel
                {
                    Id = id,
                    Nome = collection["Nome"].ToString(),
                    Descricao = collection["Descricao"].ToString(),
                    DataInicio = string.IsNullOrEmpty(collection["DataInicio"]) ? (DateTime?)null : Convert.ToDateTime(collection["DataInicio"]),
                    DataFim = string.IsNullOrEmpty(collection["DataFim"]) ? (DateTime?)null : Convert.ToDateTime(collection["DataFim"]),
                };
                if (atividade == null) return NotFound();
                _atividadesBusiness.Alterar(atividade);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var atividade = _atividadesBusiness.Obter(id);
            if (atividade == null) return NotFound();
            return View(atividade);
        }

        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _atividadesBusiness.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: Arquivo/Details/5
        public ActionResult Details(int id)
        {
            var atividade = _atividadesBusiness.Obter(id);
            if (atividade == null) return NotFound();
            return View(atividade);
        }
    }
}
