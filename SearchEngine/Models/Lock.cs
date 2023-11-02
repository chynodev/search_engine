using System.Text.Json.Serialization;
using SearchEngine.Extensions;
using SearchEngine.Interfaces;

namespace SearchEngine.Models
{
    public class Lock : ISearchable
    {
        
        public Guid Id { get; set; }
        
        public Guid BuildingId { get; set; }
        
        [JsonIgnore]
        public Building Building { get; set; }

        
        public string Type { get; set; }
        
        public string Name { get; set; }
        
        public string SerialNumber { get; set; }
        
        public string Floor { get; set; }
        
        public string RoomNumber { get; set; }
        
        public string Description { get; set; }

        public int CalculateSearchWeight(string text)
        {
            int weight = 0;

            weight += Name.CalculateSearchWeight(text, 10);
            weight += SerialNumber.CalculateSearchWeight(text, 8);
            weight += Floor.CalculateSearchWeight(text, 6);
            weight += RoomNumber.CalculateSearchWeight(text, 6);
            weight += Description.CalculateSearchWeight(text, 6);
            weight += Type.CalculateSearchWeight(text, 3);

            weight += Building?.Name.CalculateSearchWeight(text, 8) ?? 0;
            weight += Building?.Shortcut.CalculateSearchWeight(text, 5) ?? 0;

            return weight;
        }

    }
    }