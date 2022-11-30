using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs;
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
    public class CinemaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ReadCinemaDTO cinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);
                return Ok(cinemaDTO);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult RecuperaCinema([FromQuery] string nomeDoFilme )
        {
            List<Cinema> cinemas;
            cinemas = _context.Cinemas.ToList();

            if (cinemas == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                            where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeDoFilme)
                            select cinema;
                
                cinemas = query.ToList();
            }
            List<ReadCinemaDTO> readDTO = _mapper.Map<List<ReadCinemaDTO>>(cinemas);

            return Ok(readDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
