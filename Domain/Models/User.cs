namespace Domain.Models;

public class User
{
    // # Fields
    public int Id { get; set; }
    public string UserName { get; set; }
    public List<Todo> Todos { get; set; }
}