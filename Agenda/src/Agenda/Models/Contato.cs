using System;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class Contato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o campo Nome.")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Tamanho minimo de 1 caractere e no máximo é de 150 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Informe o campo Data de nascimento.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento {get;  set; }
        
        [StringLength(50, ErrorMessage ="Tamanho máximo é de 50 caracteres.")]
        [Display(Name = "E-Mail")]        
        public string Email { get; set; }

        public string Telefone  { get; set; }
            
        [Required(ErrorMessage = "Informe o campo Cpf.")]
        [StringLength(16,ErrorMessage = "Tamanho máximo é de 16 caracteres.")]
        public string Cpf { get; set; }
    }
}
