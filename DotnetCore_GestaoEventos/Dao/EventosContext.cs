using GestaoEventos.Portal.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEventos.Portal.Web.Dao
{
    // Ao importar o EF CORE, basta atribuir a herança da classe BASE => :DbContext
    public class EventosContext : DbContext
    {
        // Para configurar a string conexáo para a classe Base, fazemos  via construtor.
        public EventosContext(DbContextOptions<EventosContext> opcao) : base(opcao)
        { }

        // Precisamos associar as classes com as futuras Tabelas 
        // para isso usamos as propriedades com o DBSet<T>
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }

        // Vamos usar o método abaixo para fazer configuração da nossa Tabela.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Evento>().ToTable("TBEventos");
            modelBuilder.Entity<Evento>()
            .Property(p => p.Data)
            .IsRequired();
            modelBuilder.Entity<Evento>()
            .Property(p => p.Descricao)
            .IsRequired()
            .HasMaxLength(50);
            modelBuilder.Entity<Evento>()
            .Property(p => p.Local)
            .IsRequired()
            .HasMaxLength(50);
            modelBuilder.Entity<Evento>()
            .Property(p => p.Preco)
            .IsRequired();


            modelBuilder.Entity<Participante>().ToTable("TBParticipantes");
            modelBuilder.Entity<Participante>()
            .Property(p => p.Cpf)
            .IsRequired()
            .HasMaxLength(11);
            modelBuilder.Entity<Participante>()
            .Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(50);
            modelBuilder.Entity<Participante>()
            .Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(60);
            modelBuilder.Entity<Participante>()
            .Property(p => p.DataNascimento)
            .IsRequired();
        }
    }
}
