using System.Text.Json.Serialization;
using SearchEngine.Extensions;
using SearchEngine.Interfaces;

namespace SearchEngine.Models
{
    public class Group : ISearchable
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public int CalculateSearchWeight(string text)
        {
            int weight = 0;

            weight += Name.CalculateSearchWeight(text, 9);
            weight += Description.CalculateSearchWeight(text, 5);

            return weight;
        }
    }
}