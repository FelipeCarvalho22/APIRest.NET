using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Controllers.Models
{
    public class Filme
    {
        [Required(ErrorMessage ="O Campo Titulo é Obrigatório")]                                //Esta anotação torna obrigatórioa a escrita de algo neste campo
        public string Titulo { get; set; }

        [Required(ErrorMessage ="O Campo Diretor é Obrigatório")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "Genero não pode ter mais de 30 caracteres")]          //Esta anotação limita a quantidade de caracteres no campo
        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage ="Limites devem ser entre 1-600min")]                       //Esta anotação limita o range do campo
        public int Duracao { get; set; }
        public int Id { get; set; }

        //ErrorMesage define o que será aprensentado ao usuario caso um erro ocorra, bom para tradução das mensagens
    }
}
