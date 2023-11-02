using SearchEngine.Interfaces;
using SearchEngine.Models;

namespace SearchEngine.Services
{
    public class MockDataService : IDataProvider
    {
        public DataFile Context { get; private set; }

        public MockDataService()
        {
            LoadData();
        }

        protected void LoadData()
        {
            Context = new()
            {
                Buildings = new()
                {
                    new Building { Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), Name = "Name", Description = "Description1" }, // 90
                    new Building { Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2"), Name = "Namee", Description = "Description2" }, // 9
                    new Building { Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA3"), Name = "Building3", Description = "Description3" } // 0
                },

                Locks = new()
                {
                    new Lock { Id = Guid.NewGuid(), Name = "Name", Description = "Description1", BuildingId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA") }, // 180
                    new Lock { Id = Guid.NewGuid(), Name = "Lock2", Description = "Description2", BuildingId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2") }, // 8
                    new Lock { Id = Guid.NewGuid(), Name = "Name", Description = "Description3", BuildingId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA3") } // 100
                },

                Media = new()
                {
                    new Medium { Id = Guid.NewGuid(), SerialNumber = "Name", Description = "Description1", GroupId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA") }, // 80
                    new Medium { Id = Guid.NewGuid(), SerialNumber = "Medium2", Description = "Description2", GroupId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2") }, // 8
                    new Medium { Id = Guid.NewGuid(), SerialNumber = "Medium3", Description = "Description3", GroupId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA3") } // 0
                },

                Groups = new()
                {
                    new Group { Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"), Name = "dasdas", Description = "Description1" }, // 0
                    new Group { Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2"), Name = "Namee", Description = "Description2" }, // 9
                    new Group { Id = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA3"), Name = "Group3", Description = "Description3" } // 0
                }
            };

            // Populate transitive fields
            Context.Locks.ForEach(l => l.Building = Context.Buildings.FirstOrDefault(b => b.Id == l.BuildingId));
            Context.Media.ForEach(m => m.Group = Context.Groups.FirstOrDefault(g => g.Id == m.GroupId));
        }
    }
}
