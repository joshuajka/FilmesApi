using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.DTOs
{
    public class UpdateCinemaDTO
    {
        [Required]
        public string Nome { get; set; }
    }
}
