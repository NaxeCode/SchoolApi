using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;

namespace SchoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchoolController : ControllerBase
{
    private readonly SchoolContext _context;

    public SchoolController(SchoolContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Class>>> GetClass()
    {
        return await _context.Classes.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Class>> PostClass(Class @class)
    {
        _context.Classes.Add(@class);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(@class), new { id = @class.Id }, @class);
    }
}