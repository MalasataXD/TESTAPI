using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace HttpClients.Implementations;

public class UserHttpClient : IUserService
{
    // # Fields
    private readonly HttpClient _client;
    
    // # Constructor
    public UserHttpClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<User> Create(UserCreationDto dto)
    {
        HttpResponseMessage response = await _client.PostAsJsonAsync("/user", dto);
        string result = await response.Content.ReadAsStringAsync();
        Console.Write(result);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception();
        }

        User user = JsonSerializer.Deserialize<User>(result,
            new JsonSerializerOptions{PropertyNameCaseInsensitive = true})!;

    return user;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        string uri = "/user";
        HttpResponseMessage response = await _client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<User> users = JsonSerializer.Deserialize<IEnumerable<User>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return users;
    }
}