using Shared.Models;

namespace FileData;

public class DataContainer
{
    // # Fields
    public ICollection<User> Users { get; set; }
    public ICollection<Todo> Todos { get; set; }
}