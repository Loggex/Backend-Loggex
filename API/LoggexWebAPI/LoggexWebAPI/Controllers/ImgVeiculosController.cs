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

namespace LoggexWebAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImgVeiculosController : ControllerBase
    {
        private readonly LoggexContext _context;

        public ImgVeiculosController(LoggexContext context)
        {
            _context = context;
        }

        // GET: api/ImgVeiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImgVeiculo>>> GetImgVeiculos()
        {
            return await _context.ImgVeiculos.ToListAsync();
        }

        // GET: api/ImgVeiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImgVeiculo>> GetImgVeiculo(int id)
        {
            var imgVeiculo = await _context.ImgVeiculos.FindAsync(id);

            if (imgVeiculo == null)
            {
                return NotFound();
            }

            return imgVeiculo;
        }

        // PUT: api/ImgVeiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImgVeiculo(int id, ImgVeiculo imgVeiculo)
        {
            if (id != imgVeiculo.IdImagem)
            {
                return BadRequest();
            }

            _context.Entry(imgVeiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImgVeiculoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ImgVeiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImgVeiculo>> PostImgVeiculo(ImgVeiculo imgVeiculo)
        {
            _context.ImgVeiculos.Add(imgVeiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImgVeiculo", new { id = imgVeiculo.IdImagem }, imgVeiculo);
        }

        // DELETE: api/ImgVeiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImgVeiculo(int id)
        {
            var imgVeiculo = await _context.ImgVeiculos.FindAsync(id);
            if (imgVeiculo == null)
            {
                return NotFound();
            }

            _context.ImgVeiculos.Remove(imgVeiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImgVeiculoExists(int id)
        {
            return _context.ImgVeiculos.Any(e => e.IdImagem == id);
        }
    }
}
