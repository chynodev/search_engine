namespace SearchEngine.Interfaces
{
    public interface ISearchable
    {
        int CalculateSearchWeight(string text);
    }
}
