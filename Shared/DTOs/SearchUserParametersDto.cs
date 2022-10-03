namespace Shared.DTOs;

public class SearchUserParametersDto
{
    // # Fields
    public string? UsernameContains { get; }
    
    
    // # Constructor
    public SearchUserParametersDto(string? usernameContains)
    {
        UsernameContains = usernameContains;
    }
}