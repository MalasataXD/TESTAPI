﻿namespace Shared.Models;

public class Todo
{
    // # Fields
    public int Id { get; set; }
    public User Owner { get; }
    public string Title { get; }
    public bool IsCompleted { get; }
    
    // # Constructor
    public Todo(User owner, string title)
    {
        Owner = owner;
        Title = title;
    }
}