using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController
    {
        private static List<Filme> filmes = new List<Filme>();

        [HttpPost]
        public void adicionaFIlme([FromBody] Filme filme)
        {
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
        }
    }
}
