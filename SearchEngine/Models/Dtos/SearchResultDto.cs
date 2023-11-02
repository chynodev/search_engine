﻿
using System.Text.Json.Serialization;

namespace SearchEngine.Models.Dtos
{
    public class SearchResultDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        [JsonIgnore]
        public int SearchWeight { get; set; }
    }
}
