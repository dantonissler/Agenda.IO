using System;
using System.Linq;
using Agenda.IO.Business;
using Agenda.IO.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.IO.SiteSemAngular.Controllers
{
    public class AtividadeController : Controller
    {
        AtividadeBusiness _atividadesBusiness = new AtividadeBusiness();

        [HttpGet]
        public IActionResult ListaDeAtividades()
        {
            var atividade = _atividadesBusiness.Obter().OrderBy(p => p.DataInicio);
            return Ok(atividade);
        }

        [HttpGet]
        public IActionResult Recuperar(int id)
        {
            var atividade = _atividadesBusiness.Obter(id);
            if (atividade == null) return NotFound();
            return Ok(atividade);
        }

        [HttpPost]
        public IActionResult Incluir([FromBody] AtividadeUpload collection)
        {
            if (ModelState.IsValid)
            {
                var atividade = collection.ToAtividade();
                _atividadesBusiness.Salvar(atividade);
                var uri = Url.Action("Recuperar", new { id = atividade.Id });
                return Created(uri, atividade); //201
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Alterar(int id, IFormCollection collection)
        {
            if(ModelState.IsValid)
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
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var atividade = _atividadesBusiness.Obter(id);
            if (atividade == null) return NotFound();
            _atividadesBusiness.Excluir(id);
            return NoContent(); //203
        }
    }
}