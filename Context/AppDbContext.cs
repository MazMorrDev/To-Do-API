using Microsoft.EntityFrameworkCore;

namespace ToDoApi;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar la entidad Task (evitar conflicto con System.Threading.Tasks.Task)
        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Description).HasMaxLength(500);
            entity.Property(t => t.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(t => t.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(t => t.User);
        });

        // Configurar la entidad User
        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Name).HasMaxLength(100);
            entity.Property(u => u.HashPassword).HasMaxLength(255);
        });

        // // Configurar la entidad UserTask (tabla de unión/relación)
        // modelBuilder.Entity<UserTask>(entity =>
        // {
        //     entity.HasKey(ut => ut.Id);

        //     // Relación con User
        //     entity.HasOne(ut => ut.User)
        //           .WithMany() // Si User tiene colección de UserTasks, usar: .WithMany(u => u.UserTasks)
        //           .HasForeignKey(ut => ut.UserId)
        //           .OnDelete(DeleteBehavior.Cascade); // Opcional: eliminar UserTasks cuando se elimine User

        //     // Relación con Task
        //     entity.HasOne(ut => ut.Task)
        //           .WithMany() // Si Task tiene colección de UserTasks, usar: .WithMany(t => t.UserTasks)
        //           .HasForeignKey(ut => ut.TaskId)
        //           .OnDelete(DeleteBehavior.Cascade); // Opcional: eliminar UserTasks cuando se elimine Task

        //     // Opcional: Índice compuesto para evitar duplicados
        //     entity.HasIndex(ut => new { ut.UserId, ut.TaskId }).IsUnique();
        // });
    }
}