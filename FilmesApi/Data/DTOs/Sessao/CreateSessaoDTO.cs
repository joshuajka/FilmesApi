using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.DTOs.Sessao
{
    public class CreateSessaoDTO
    {
        public int CinemaId { get; set; }

        public int FilmeId { get; set; }

        public DateTime HorarioDeEncerramento { get; set; }
    }
}
