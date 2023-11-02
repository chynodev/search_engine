namespace SearchEngine.Extensions
{
    public static class StringExtensions
    {
        public static int CalculateSearchWeight(this string property, string text, int weight) 
        {
            return property switch
            {
                null => 0,
                var p when p.Equals(text, StringComparison.OrdinalIgnoreCase) => 10 * weight,
                var p when p.Contains(text, StringComparison.OrdinalIgnoreCase) => weight,
                _ => 0
            };
        }
    }
}
