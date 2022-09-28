using Application.DAOInterfaces;
using Shared.Models;

namespace FileData.DAOs;

public class UserFileDao : IUserDAO
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }

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
}