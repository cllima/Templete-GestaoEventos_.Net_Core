using Microsoft.EntityFrameworkCore;

namespace GestaoEventos.Portal.Web.Dao
{
    public class GenericDao<T> where T : class
    {
        // Variáveis de contexto com PRIVATE
        private EventosContext contexto { get; set; }

        // O construtor receberá uma instância do nosso contexto.
        public GenericDao(EventosContext contexto)
        {
            this.contexto = contexto;
        }

        public void Executar(T item, TipoOperacaoDB tipo)
        {
            this.contexto.Entry<T>(item).State = (EntityState)tipo;
            this.contexto.SaveChanges();
        }

        public IEnumerable<T> Listar()
        {
            return this.contexto.Set<T>().ToList();
        }

        public T BuscarPorId(int id)
        {
            return this.contexto.Set<T>().Find(id);
        }

    }
}
