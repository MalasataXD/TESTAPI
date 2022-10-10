using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class UserLogic :IUserLogic
{
    // # Fields
    private readonly IUserDAO userDao;
    
    // # Constructor
    public UserLogic(IUserDAO userDao)
    {
        this.userDao = userDao;
    }

    // ¤ Create User
    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUserNameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User
        {
            UserName = dto.UserName
        };
    
        User created = await userDao.CreateAsync(toCreate);
    
        return created;
    }
    
    // ¤ Validate Data (Utility Method)
    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.UserName;

        if (userName.Length < 3)
        {
            throw new Exception("Username must be at least 3 characters!");
        }

        if (userName.Length > 15)
        {
            throw new Exception("Username must be less than 16 characters!");
        }



    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchUserParameters)
    {
        return userDao.GetAsync(searchUserParameters);
    }


}