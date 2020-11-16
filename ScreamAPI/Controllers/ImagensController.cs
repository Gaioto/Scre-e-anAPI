using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScreamAPI.Models;

namespace ScreamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagensController : ControllerBase
    {
        private readonly ScreenContext _context;

        public ImagensController(ScreenContext context)
        {
            _context = context;
        }

        // GET: api/Imagems
        [HttpGet("GetImagens")]
        public async Task<ActionResult<IEnumerable<Imagem>>> GetImagens()
        {
            return await _context.Imagens.Where(i => i.ExclusaoImagem == false).ToListAsync();
        }

        // GET: api/Imagems/5
        [HttpGet("GetImagem/{id}")]
        public async Task<ActionResult<Imagem>> GetImagem(int id)
        {
            var imagem = await _context.Imagens.FindAsync(id);

            if (imagem == null)
            {
                return NotFound();
            }

            return imagem;
        }

        // PUT: api/Imagems/5
        [HttpPut("PutImagem/{id}")]
        public async Task<IActionResult> PutImagem(int id, Imagem imagem)
        {
            if (id != imagem.IdImagem)
            {
                return BadRequest();
            }

            _context.Entry(imagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagemExists(id))
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

        // POST: api/Imagems
        [HttpPost("PostImagem")]
        public async Task<ActionResult<Imagem>> PostImagem(Imagem imagem)
        {
            _context.Imagens.Add(imagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImagem", new { id = imagem.IdImagem }, imagem);
        }

        // DELETE: api/Imagems/5
        [HttpDelete("DeleteImagem/{id}")]
        public async Task<ActionResult<Imagem>> DeleteImagem(int id)
        {
            var imagem = await _context.Imagens.FindAsync(id);
            if (imagem == null)
            {
                return NotFound();
            }

            imagem.ExclusaoImagem = true;
            _context.Update(imagem);
            await _context.SaveChangesAsync();

            return imagem;
        }

        private bool ImagemExists(int id)
        {
            return _context.Imagens.Any(e => e.IdImagem == id);
        }
    }
}
