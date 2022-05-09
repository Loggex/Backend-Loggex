using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using Microsoft.AspNetCore.Authorization;
using LoggexWebAPI.Interfaces;
using LoggexWebAPI.Repositories;
using LoggexWebAPI.Utils;

namespace LoggexWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        private readonly LoggexContext _context;
        private IPecaRepository _pecaRepository { get; set; }

        public PecasController(LoggexContext context)
        {
            _context = context;
            _pecaRepository = new PecaRepository();
        }

        // GET: api/Pecas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peca>>> GetPecas()
        {
            return _pecaRepository.Listar();
        }

        // GET: api/Pecas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Peca>> GetPeca(int id)
        {
            var peca = await _context.Pecas.FindAsync(id);

            if (peca == null)
            {
                return NotFound();
            }

            return peca;
        }

        // PUT: api/Pecas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Peca logUPDT)
        {
            try
            {
                Peca teste = _pecaRepository.BuscarPorID(id);
                if (teste != null)
                {
                    _pecaRepository.Atualizar(id, logUPDT);

                    return StatusCode(204);
                }

                return NotFound("O log não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        // POST: api/Pecas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Peca>> PostPeca([FromForm]  Peca peca, IFormFile arquivo)
        {
            string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
            string uploadResultado = uploadImg.UploadFile(arquivo, extensoesPermitidas);

            if (uploadResultado == "")
            {
                return BadRequest("Arquivo não encontrado");
            }

            if (uploadResultado == "Extensão não permitida")
            {
                return BadRequest("Extensão de arquivo não permitida");
            }

            peca.ImgPeca = uploadResultado;

            _context.Pecas.Add(peca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeca", new { id = peca.IdPeca }, peca);
        }

        // DELETE: api/Pecas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeca(int id)
        {
            var peca = await _context.Pecas.FindAsync(id);
            if (peca == null)
            {
                return NotFound();
            }

            _context.Pecas.Remove(peca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PecaExists(int id)
        {
            return _context.Pecas.Any(e => e.IdPeca == id);
        }
    }
}
