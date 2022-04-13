using GestaoEventos.Portal.Web.Models;

namespace GestaoEventos.Portal.Web.Dao
{
    public class EventosDao : GenericDao<Evento>
    {
      


        // Após aplicar a tipagem na classe GenericDao, devemos criar o
        // construtor e passar um objeto do nosso contexto.
        public EventosDao(EventosContext contexto) : base(contexto)
        { }

    }
}
