using FilmesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.DTOs.Sessao
{
    public class ReadSessaoDTO
    {
        public int Id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}
