namespace ToDoApi;

public class Tasks
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int UserId { get; set; }
    // Propiedad de navegación
    public virtual Users? User { get; set; }
}
