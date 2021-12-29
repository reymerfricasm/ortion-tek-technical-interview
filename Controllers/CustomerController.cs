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
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<Exception> _logger;

        public CustomerController(ApplicationDbContext context, ILogger<Exception> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _context.Customers
                                        .Include(a => a.Adresses)
                                        .ThenInclude(a => a.City)
                                        .ToListAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has ocurred trying to get Customers.");
                return NoContent();
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _context.Customers.FindAsync(id);
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
                _logger.LogError(ex, "An error has ocurred trying to get Customers by Id.");
                return NoContent();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer model)
        {
            try
            {
                var data = await _context.Customers.AddAsync(model);
                await _context.SaveChangesAsync();
                return Created("Customer/POST", data.Entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has ocurred trying to post Customer.");
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Customer model)
        {
            try
            {
                var data = await _context.Customers.FindAsync(id);
                if(data is null)
                {
                    return NotFound();
                }

                data.Name = model.Name;
                data.Nickname = model.Nickname;
                data.LastName = model.LastName;
                data.IdNumber = model.IdNumber;
                data.Birthdate = model.Birthdate;
                data.Email = model.Email;
                data.Phone = model.Phone;
                data.Inactive = model.Inactive;

                _context.Entry(data).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has ocurred trying to put Customer.");
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _context.Customers.FindAsync(id);
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
                _logger.LogError(ex, "An error has ocurred trying to delete Customer.");
                return BadRequest();
            }
        }
    }
}