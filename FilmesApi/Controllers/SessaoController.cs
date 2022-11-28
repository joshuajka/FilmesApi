using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs.Sessao;
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
    public class SessaoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDTO sessaoDTO)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDTO);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet]
        public IEnumerable<Sessao> RecuperaSessoes()
        {
            return _context.Sessoes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDTO sessaoDTO = _mapper.Map<ReadSessaoDTO>(sessao);
                return Ok(sessaoDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDTO sessaoNova)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
            {
                return NotFound();
            }
            _mapper.Map(sessaoNova, sessao);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaSessao(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
            {
                return NotFound();
            }
            _context.Remove(sessao);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
