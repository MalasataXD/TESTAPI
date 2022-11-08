using Domain.DTOs;
using Domain.Models;

namespace Application.DAOInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUserNameAsync(string userName);
    
    Task<User?> GetByIdAsync(int id);

    Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchUserParameters);
}