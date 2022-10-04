using Shared.DTOs;
using Shared.Models;

namespace Application.DAOInterfaces;

public interface ITodoDao
{
    Task<Todo> CreateAsync(Todo todo);
    Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchParameters);
    Task<Todo?> GetByIdAsync(int todoId);
    Task UpdateAsync(Todo toUpdate);
    Task DeleteAsync(int id);
}