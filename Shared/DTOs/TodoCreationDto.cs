namespace Shared.DTOs;

public class TodoCreationDto
{
    // # Fields
    public int OwnerId { get; }
    public string Title { get; }
    
    // # Constructor
    public TodoCreationDto(int ownerId, string title)
    {
        OwnerId = ownerId;
        Title = title;
    }
    
    
    
}