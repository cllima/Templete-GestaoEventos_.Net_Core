using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace GestaoEventos.Portal.Web.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="DESCRIÇÂO")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name ="DATA DO EVENTO")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required]
        [Display(Name ="LOCAL")]
        public string Local { get; set; }

        [Required]
        [Display(Name="PREÇO")]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }

        // Propriedade de Navegação cria o relacionamento entre as futuras Tabelas.
        public ICollection<Participante> Participantes { get; set; }
    }
}
