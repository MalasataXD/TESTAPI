using Application.DAOInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.Implementations;

public class TodoEfcDao : ITodoDao
{
    private readonly TodoContext _context;
    
    // # Constructor
    public TodoEfcDao(TodoContext context)
    {
        _context = context;
    }
    
    public async Task<Todo> CreateAsync(Todo todo)
    {
        EntityEntry<Todo> added = await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchParameters)
    {
        
        IQueryable<Todo> query = _context.Todos.Include(todo => todo.Owner).AsQueryable();

        // ¤ Username
        if (!string.IsNullOrEmpty(searchParameters.Username))
        {
            query = query.Where(todo => todo.Owner.UserName.ToLower().Equals(searchParameters.Username.ToLower()));
        }
        
        // ¤ UserId
        if (searchParameters.UserId != null)
        {
            query = query.Where(todo => todo.Owner.Id == searchParameters.UserId);
        }
        
        // ¤ CompletedStatus
        if (searchParameters.CompletedStatus != null)
        {
            query = query.Where(todo => todo.IsCompleted == searchParameters.CompletedStatus);
        }
        
        // ¤ Title
        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
        {
            query = query.Where(todo => todo.Title.ToLower().Contains(searchParameters.TitleContains.ToLower()));
        }

        List<Todo> result = await query.ToListAsync();
        return result;
    }

    public async Task UpdateAsync(Todo todo)
    {
        _context.ChangeTracker.Clear();
        _context.Todos.Update(todo);
        await _context.SaveChangesAsync();
    }

    public async Task<Todo?> GetByIdAsync(int todoId)
    {
        Todo? found = await _context.Todos.FindAsync(todoId);
        return found;
    }

    public async Task DeleteAsync(int id)
    {
        Todo? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"Todo with id {id} not found!");
        }

        _context.Todos.Remove(existing);
        await _context.SaveChangesAsync();
    }
}