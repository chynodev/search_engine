using System.Text.Json;
using SearchEngine.Interfaces;
using SearchEngine.Models;

public class DataFileService : IDataProvider
{
    private readonly string _dataFilePath = "seed_data.json";
    public DataFile Context { get; private set; }

    public DataFileService()
    {
        LoadData();
    }

    protected void LoadData()
    {
        var jsonData = File.ReadAllText(_dataFilePath);

        Context = JsonSerializer.Deserialize<DataFile>(jsonData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        // Populate transitive fields
        Context.Locks.ForEach(l => l.Building = Context.Buildings.FirstOrDefault(b => b.Id == l.BuildingId));
        Context.Media.ForEach(m => m.Group = Context.Groups.FirstOrDefault(g => g.Id == m.GroupId));
    }
}
