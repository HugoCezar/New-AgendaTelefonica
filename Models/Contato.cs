using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_Telefonica.Models
{
    public class Contato
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Telefone_Residencial { get; set; }
        [Required(ErrorMessage = "O campo Telefone Celular é obrigatório.")]
        public string Telefone_Celular { get; set; }
        public string Telefone_Comercial { get; set; }
    }
}
