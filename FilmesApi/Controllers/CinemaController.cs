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

    }
}
