using GestaoEventos.Portal.Web.Models;

namespace GestaoEventos.Portal.Web.Dao
{
    public class ParticipantesDao : GenericDao<Participante>
    {
        public EventosContext Contexto { get; set; }

        public ParticipantesDao(EventosContext eventosContext) : base(eventosContext)
        {
        }

        //método para listar os participantes por evento.
        public IEnumerable<Participante> ListarPorEventos(int idEvento)
        {
            return Contexto.Participantes
            .Where(p => p.EventoInfoId == idEvento)
            .ToList();
        }



    }
}
