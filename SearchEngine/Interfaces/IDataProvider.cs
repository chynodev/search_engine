using SearchEngine.Models;

namespace SearchEngine.Interfaces
{
    public interface IDataProvider
    {
        DataFile Context { get; }
    }
}
