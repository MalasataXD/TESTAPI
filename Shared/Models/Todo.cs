namespace Shared.Models;

public class Todo
{
    // # Fields
    public int Id { get; set; }
    public User Owner { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    
    // # Constructor
    public Todo(User owner, string title)
    {
        Owner = owner;
        Title = title;
    }
}