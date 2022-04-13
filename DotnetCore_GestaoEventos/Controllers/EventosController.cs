using GestaoEventos.Portal.Web.Dao;
using GestaoEventos.Portal.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEventos.Portal.Web.Controllers
{
    public class EventosController : Controller
    {
        private EventosDao eventosDB { get; set; }

        // Vamos configurar o nosso CONSTRUTOR p/ receber a injeção do
        // objeto configurado na classe Startup, como Injeção de Dependência.
        public EventosController(EventosContext contexto)
        {
            eventosDB = new EventosDao(contexto);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IncluirEvento()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IncluirEvento(Evento evento)
        {
            /*if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Sua requisição não foi processada.");
                return View();
            }*/

            try
            {
                // Incluir Evento já que não houve falha na página.
                eventosDB.Executar(evento, TipoOperacaoDB.Added);
                
                // Redireciona o usuário a lista de eventos cadastradas.
                return RedirectToAction("ListarEventos");

            }
            catch (System.Exception ex)
            {
                ViewBag.MsgErro = ex.Message;
                return View("Error");
            }
         
        }

        public IActionResult ListarEventos()
        {
            try
            {
                // Vamos chamar o método listar dentro dos parentes, fazendo de forma direta.
                return View(eventosDB.Listar());
            }
            catch (System.Exception ex)
            {
                ViewBag.MsgErro = ex.Message;
                return View("Error");
            }

        }

        public IActionResult Alterar(int id, string viewName)
        {
            try
            {
                var evento = eventosDB.BuscarPorId(id);

                if (evento == null)
                {
                    ViewBag.MsgErro = "O evento não foi localizado";
                    return View();
                }

                return View(viewName, evento);

            }
            catch (System.Exception ex)
            {
                ViewBag.MsgErro = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Alterar(Evento evento)
        {
            /*if (!ModelState.IsValid)
            {
                ViewBag.MsgErro = "A sua alteração falhou, verifique!";
                return View();
            }*/

            try
            {
                eventosDB.Executar(evento, TipoOperacaoDB.Modified);
                return RedirectToAction("ListarEventos");
            }
            catch (System.Exception ex)
            {
                ViewBag.MsgErro = ex.Message;
                return View("Error");
            }
        }

        public IActionResult Remover(int id)
        {
            try
            {
                var evento = eventosDB.BuscarPorId(id);

                if (evento == null)
                {
                    ViewBag.MsgErro = "Evento não localizado";
                    return View();
                }
                return View(evento);

            }
            catch (System.Exception ex)
            {
                ViewBag.MsgErro = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Remover(Evento evento)
        {
            try
            {
                eventosDB.Executar(evento, TipoOperacaoDB.Deleted);
                return RedirectToAction("ListarEventos");

            }
            catch (System.Exception ex)
            {
                ViewBag.MsgErro = ex.Message;
                return View("Error");
            }
        }

    }
}
