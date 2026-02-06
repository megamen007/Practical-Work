using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Praktika.Praktika.Application.Models;
using Praktika.Praktika.Domain.Entities;
using Praktika.Praktika.Infrastructure.Persistence;

namespace Praktika.Praktika.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public ItemsController(PraktikaDbContext db)
        {
            _db = db;
        }
        private readonly PraktikaDbContext _db;

        [HttpGet]

        public async Task<IActionResult> AllItems()
        {
            var items = await _db.Items.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> AllItems(int id)
        {
            var item = await _db.Items.SingleOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return NotFound($"Item Code {id} not exists!");
            }
            return Ok(item);
        }


        [HttpPost]

        public async Task<IActionResult> AddItem([FromForm]mdlItem mdl)
        {
            using var stream = new MemoryStream();
            await mdl.Image.CopyToAsync(stream);
            var Item = new Item
            {
                Name = mdl.Name,
                Price = mdl.Price,
                Notes = mdl.Notes,
                CategoryId = mdl.CategoryId,
                Image = stream.ToArray()
            };
            await _db.Items.AddAsync(Item);
            await _db.SaveChangesAsync();
            return Ok(Item);
        }
        
    }
}