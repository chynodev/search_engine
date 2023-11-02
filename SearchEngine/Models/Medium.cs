using System.Text.Json.Serialization;
using SearchEngine.Extensions;

namespace SearchEngine.Models
{
    public class Medium
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }

        [JsonIgnore]
        public Group Group { get; set; }

        public string Type { get; set; }
        public string Owner { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }

        public int CalculateSearchWeight(string text)
        {
            int weight = 0;

            weight += Owner.CalculateSearchWeight(text, 10);
            weight += SerialNumber.CalculateSearchWeight(text, 8);
            weight += Description.CalculateSearchWeight(text, 6);
            weight += Type.CalculateSearchWeight(text, 3);

            weight += Group?.Name.CalculateSearchWeight(text, 8) ?? 0;

            return weight;
        }

    }
}