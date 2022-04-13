

namespace GestaoEventos.Portal.Web.Dao
{
    public class DbInitializer
    {
        public static void Inicializador(EventosContext dbeventos)
        {
            // Assegura que o banco de dados seja sempre criado.
            dbeventos.Database.EnsureCreated();
        }
    }
}
