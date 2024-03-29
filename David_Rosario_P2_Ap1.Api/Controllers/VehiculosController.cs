﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using David_Rosario_P2_Ap1.Api.DAL;
using Library.Models;

namespace David_Rosario_P2_Ap1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly Contexto _context;

        public VehiculosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Vehiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculos>>> GetVehiculos()
        {
            return await _context.Vehiculos.ToListAsync();
        }

        // GET: api/Vehiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculos>> GetVehiculos(int id)
        {
            if(_context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculos = await _context.Vehiculos
                .Include(v => v.VehiculosDetalles)
                .Where(v => v.VehiculoId == id)
                .FirstOrDefaultAsync();

            if(vehiculos == null)
            {
                return NotFound();
            }

            return vehiculos;
        }

        // PUT: api/Vehiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculos(int id, Vehiculos vehiculos)
        {
            if (id != vehiculos.VehiculoId)
            {
                return BadRequest();
            }

            _context.Entry(vehiculos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculosExists(id))
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

        // POST: api/Vehiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehiculos>> PostVehiculos(Vehiculos vehiculos)
        {
           if(!VehiculosExists(vehiculos.VehiculoId))
                _context.Vehiculos.Add(vehiculos);
           else
                _context.Vehiculos.Update(vehiculos);

           await _context.SaveChangesAsync();

            return Ok(vehiculos);
        }

        // DELETE: api/Vehiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculos(int id)
        {
            var vehiculos = await _context.Vehiculos.FindAsync(id);
            if (vehiculos == null)
            {
                return NotFound();
            }

            _context.Vehiculos.Remove(vehiculos);
            await _context.SaveChangesAsync();

            return NoContent();
        }



		[HttpDelete("{vehiculoId}/Detalle/{detalleId}")]
		public async Task<IActionResult> DeleteVehiculos(int vehiculoId, int detalleId)
		{
            var vehiculos = await _context.Vehiculos.Include(v => v.VehiculosDetalles).FirstOrDefaultAsync(v => v.VehiculoId == vehiculoId);
			if (vehiculos == null)
			{
				return NotFound();
			}

            var detalle = vehiculos.VehiculosDetalles.FirstOrDefault(d => d.Id == detalleId);

            if (detalle == null)
            {
                return NotFound();
            }

			vehiculos.VehiculosDetalles.Remove(detalle);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool VehiculosExists(int id)
        {
            return _context.Vehiculos.Any(e => e.VehiculoId == id);
        }
    }
}
