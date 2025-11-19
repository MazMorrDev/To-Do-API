using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ToDoApi;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Users>>> GetProducts()
    {
        return await _context.Users.ToListAsync();
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Users>> GetProduct(int id)
    {
        var product = await _context.Users.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    // PUT: api/Products/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Users users)
    {
        if (id != users.Id)
        {
            return BadRequest();
        }

        _context.Entry(users).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
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

    // POST: api/Users
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Users>> PostProduct(Users users)
    {
        _context.Users.Add(users);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = users.Id }, users);
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Users.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Users.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return _context.Users.Any(e => e.Id == id);
    }
}

