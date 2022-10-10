using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface ITodoLogic
{
    Task<Todo> CreateAsync(TodoCreationDto dto);
    Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchParameters);
    Task UpdateAsync(TodoUpdateDto todo);

    Task<TodoBasicDto> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}