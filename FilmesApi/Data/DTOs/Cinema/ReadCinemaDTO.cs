using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FilmesApi.Models;

namespace FilmesApi.Data.DTOs
{
    public class ReadCinemaDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public Endereco Endereco { get; set; }

        public Gerente Gerente { get; set; } 
    }
}
