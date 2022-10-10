using System.Security;

namespace Shared.Models;

public class User
{
    // # Fields
    public string UserName { get; set; }
    public string PassWord { get; set; }
    public string Email { get; set; }
    public string Domain { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public int Age { get; set; }
    public int SecurityLevel { get; set; }
}