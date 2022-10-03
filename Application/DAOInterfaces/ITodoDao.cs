using Shared.DTOs;
using Shared.Models;

namespace Application.DAOInterfaces;

public interface ITodoDao
{
    Task<Todo> CreateAsync(Todo todo);
    Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchParameters);
}