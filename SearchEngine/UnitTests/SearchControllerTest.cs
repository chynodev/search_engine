using SearchEngine.Controllers;
using SearchEngine.Interfaces;
using SearchEngine.Models.Dtos;
using SearchEngine.Models;
using Xunit;
using SearchEngine.Services;

namespace SearchEngine.UnitTests
{
    public class SearchControllerTest
    {
        private readonly SearchController controller;
        private readonly IDataProvider mockData = new MockDataService();

        public SearchControllerTest()
        {
            controller = new SearchController(mockData);
        }

        [Fact]
        public void Search_HappyPath()
        {
            var result = controller.Search("name");

            Assert.Equal(mockData.Context.Locks[0].Id, result[0].Id);
            Assert.Equal(mockData.Context.Locks[2].Id, result[1].Id);
            Assert.Equal(mockData.Context.Buildings[0].Id, result[2].Id);
            Assert.Equal(mockData.Context.Media[0].Id, result[3].Id);
        }

        
    }
}
