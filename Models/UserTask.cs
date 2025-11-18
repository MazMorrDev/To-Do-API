namespace ToDoApi;

public class UserTask
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TaskId { get; set; }

    // Propiedades de navegación (opcionales, dependiendo de tu ORM)
    public virtual User? User { get; set; }
    public virtual Task? Task { get; set; }
}
