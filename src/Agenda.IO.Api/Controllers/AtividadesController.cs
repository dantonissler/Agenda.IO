using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.IO.Business;
using Agenda.IO.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.IO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadesController : ControllerBase
    {
        AtividadeBusiness _atividadesBusiness = new AtividadeBusiness();

        [HttpGet]
        public IActionResult ListaAtividades()
        {
            var atividade = _atividadesBusiness.Obter().OrderBy(p => p.DataInicio).Select(l => l.ToApi()).ToList();
            return Ok(atividade);
        }
    }
}
