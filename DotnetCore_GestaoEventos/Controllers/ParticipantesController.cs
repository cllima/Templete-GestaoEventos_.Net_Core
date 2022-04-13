using GestaoEventos.Portal.Web.Dao;
using GestaoEventos.Portal.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEventos.Portal.Web.Controllers
{
    public class ParticipantesController : Controller
    {
        private ParticipantesDao participantesDB { get; set; }
        private EventosDao eventosDB { get; set; }

        //Inclusão também das referências ao contexto (injeção 
        //de dependência), EventosDao e ParticipantesDao:
        public ParticipantesController(EventosContext eventosContext)
        {
            eventosDB = new EventosDao(eventosContext);
            participantesDB = new ParticipantesDao(eventosContext);
        }
        public IActionResult Index() 
        {
            return View();
        }

        // Falta fazer os métodos abaixo pag. 455
        public IActionResult IncluirParticipante()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IncluirParticipante(Participante participante)
        {
            return View();
        }

        public IActionResult ListarParticipantes(int idEvento)
        {
            return View();
        }
    }
}
