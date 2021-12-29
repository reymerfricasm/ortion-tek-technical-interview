using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using orion_tek_technical_interview.Data;
using orion_tek_technical_interview.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace orion_tek_technical_interview.Controllers
{
    [ApiController]
    [Route("api/states")]
    public class StateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<Exception> _logger;

        public StateController(ApplicationDbContext context, ILogger<Exception> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _context.States.ToListAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has ocurred trying to get States.");
                return NoContent();
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _context.States.FindAsync(id);
                if(data is null)
                {
                    return NotFound();
                } 
                else 
                {
                    return Ok(data); 
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has ocurred trying to get States by Id.");
                return NoContent();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] State model)
        {
            try
            {
                var data = await _context.States.AddAsync(model);
                await _context.SaveChangesAsync();
                return Created("State/POST", data.Entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has ocurred trying to post State.");
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] State model)
        {
            try
            {
                var data = await _context.States.FindAsync(id);
                if(data is null)
                {
                    return NotFound();
                }

                data.Name = model.Name;
                data.CityId = model.CityId;

                _context.Entry(data).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has ocurred trying to put State.");
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _context.States.FindAsync(id);
                if(data is null)
                {
                    return NotFound();
                } 
                _context.Entry(data).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has ocurred trying to delete State.");
                return BadRequest();
            }
        }
    }
}