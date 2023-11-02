using Microsoft.AspNetCore.Mvc;
using SearchEngine.Interfaces;
using SearchEngine.Models;
using SearchEngine.Models.Dtos;

namespace SearchEngine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        public IDataProvider Data { get; }

        public SearchController(IDataProvider data)
        {
            Data = data;
        }

        [HttpGet]
        // normally I would return a task wrapping this return type because I would access the DB asynchronously
        public List<SearchResultDto> Search(string text)
        {
            var buildings = Data.Context.Buildings.Select(b => new SearchResultDto { Id = b.Id, Name = b.Name, Description = b.Description, SearchWeight = b.CalculateSearchWeight(text), Type = nameof(Building) });
            var locks = Data.Context.Locks.Select(l => new SearchResultDto { Id = l.Id, Name = $"{l.Name} - {l.SerialNumber}", Description = l.Description, SearchWeight = l.CalculateSearchWeight(text), Type = nameof(Lock) });
            var media = Data.Context.Media.Select(m => new SearchResultDto { Id = m.Id, Name = m.SerialNumber, Description = m.Description, SearchWeight = m.CalculateSearchWeight(text), Type = nameof(Medium) });
            var groups = Data.Context.Groups.Select(g => new SearchResultDto { Id = g.Id, Name = g.Name, Description = g.Description, SearchWeight = g.CalculateSearchWeight(text), Type = nameof(Group) });

            var orderedResult = buildings
                .Concat(locks)
                .Concat(media)
                .Concat(groups)
                .OrderByDescending(x => x.SearchWeight)
                .ThenBy(x => x.Name)
                .Take(15)
                .ToList();

            return orderedResult;
        }
    }
}
