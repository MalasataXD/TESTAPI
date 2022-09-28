using System.Text.Json;
using Shared.Models;

namespace FileData;

public class FileContext
{
    // # Fields
    private const string FilePath = "data.json";
    private DataContainer? dataContainer;
    public ICollection<Todo> Todos
    {
        get
        {
            LoadData();
            return dataContainer!.Todos;
        }
    }
    public ICollection<User> Users
    {
        get
        {
            LoadData();
            return dataContainer!.Users;
        }
    }

    // ¤ Extract data from file
    private void LoadData()
    {
        // # Check if data already has been loaded
        // * If data already has been loaded the DataContainer will already exist
        if (dataContainer != null)
        {
            return;
        }
        
        // # Check if there is a file at the filePath, then create a DataContainer
        if (!File.Exists(FilePath))
        {
            dataContainer = new()
            {
                Todos = new List<Todo>(),
                Users = new List<User>()
            };
            return;
        }
        // # Extract content from file.
        string content = File.ReadAllText(FilePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    // ¤ Put data into file
    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer);
        File.WriteAllText(FilePath,serialized);
        dataContainer = null;
    }


}