using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestaoEventos.Portal.Web.Models
{
    public class Participante
    {
        public int Id { get; set; }

        [Display(Name ="EVENTO")]
        public int EventoInfoId { get; set; }

        [Required]
        [Display(Name ="NOME")]
        public string Nome { get; set; }

        [Required]
        [Display(Name ="E-MAIL")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name ="CPF")]
        [StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; }

        [Display(Name ="DATA DE NASCIMENTO")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }


        // Propriedade de Navegação criam o relacionamento entre as futuras Tabelas.
        public Evento EventoInfo { get; set; }

    }
}
