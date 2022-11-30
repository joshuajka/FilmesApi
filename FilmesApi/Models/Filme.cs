using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesApi.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Título é um campo obrigatório")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8}$",ErrorMessage = "Password must meet requirements")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Diretor é um campo obrigatório")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "Gênero não pode ultrapassar 30 caracteres")]
        public string Genero { get; set; }
        
        [Range(1,600, ErrorMessage = "O campo duração deve conter entre 1 e 600 minutos")]
        public int Duracao { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }

        public int ClassificacaoEtaria { get; set; }

    }
}
