using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactoApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactoApi.Controllers
{   

    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly ContactosDBContext _contexto;

        public ContactosController(ContactosDBContext contexto)
        {
            _contexto = contexto;
        }

        // GET: api/Contactos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> Get()
        {
            return await _contexto.Contacto.ToListAsync();
        }

        // GET: api/Contactos/5
        [HttpGet("{id}", Name = "GetItem")]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetItem(int id)
        {
            var contactoitem = await _contexto.Contacto.FirstOrDefaultAsync(x => x.ContactoId == id);

            if (contactoitem == null)
            {
                return NotFound();
            }

            return Ok(contactoitem);
        }

        // POST: api/Contactos
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Contacto>>> Post (Contacto Item)
        {
            _contexto.Contacto.Add(Item);

            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = Item.ContactoId }, Item);
        }

        // PUT: api/Contactos/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Contacto Item)
        {
            if (id != Item.ContactoId)
            {
                return BadRequest();
            }

            _contexto.Entry(Item).State = EntityState.Modified;

            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var contactoitem = await _contexto.Contacto.FindAsync(id);

            if (contactoitem == null)
            {
                return NotFound();
            }

            _contexto.Contacto.Remove(contactoitem);

            await _contexto.SaveChangesAsync();

            return NoContent();
        }
    }
}
