using Microsoft.EntityFrameworkCore;

namespace ToDoApi;

public class AppDbContext(DbContextOptions<AppDbContext> options) : BdContext(options)
{
    DbSet<>
}
