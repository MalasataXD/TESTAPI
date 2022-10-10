using Application.DAOInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace FileData.DAOs;

public class UserFileDao : IUserDAO
{
    private readonly FileContext context;

    // # Constructor
    public UserFileDao(FileContext context)
    {
        this.context = context;
    }

    // ¤ Create  User
    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }

        user.Id = userId;

        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    // ¤ Get user by Name
    public Task<User?> GetByUserNameAsync(string userName)
    {
        User userToFind = null;

        foreach (var user in context.Users)
        {
            if (user.UserName.Equals(userName))
            {
                userToFind = user;
            }
        }

        return Task.FromResult(userToFind);
    }
    
    // ¤ Get user by Id
    public Task<User?> GetByIdAsync(int id)
    {
        User userToFind = null;

        foreach (var user in context.Users)
        {
            if (user.Id == id)
            {
                userToFind = user;
            }
        }

        return Task.FromResult(userToFind);
    }
    
    // ¤ Get ASYNC
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchUserParameters)
    {
        IEnumerable<User> users = context.Users.AsEnumerable();
        if (searchUserParameters.UsernameContains != null)
        {
            users = context.Users.Where(u =>
                u.UserName.Contains(searchUserParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(users);
    }
}