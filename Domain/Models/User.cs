using System.Text.Json.Serialization;

namespace Domain.Models;

public class User
{
    // # Fields
    public int Id { get; set; }
    public string UserName { get; set; }
    [JsonIgnore]
    public ICollection<Todo> Todos { get; set; }
}