using Shared.Models;

namespace Shared.DTOs;

public class SearchTodoParametersDto
{
    // # Fields
    public string? Username { get; }
    public int? UserId { get; }
    public bool? CompletedStatus {get;}
    public string? TitleContains { get; }
    
    // # Constructor
    public SearchTodoParametersDto(string? username, int? userId, bool? completedStatus, string? titleContains)
    {
        Username = username;
        UserId = userId;
        CompletedStatus = completedStatus;
        TitleContains = titleContains;
    }
    
    
    
}