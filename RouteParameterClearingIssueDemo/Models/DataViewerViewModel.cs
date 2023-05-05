namespace RouteParameterClearingIssueDemo.Models
{
    public class DataViewerViewModel
    {
        public List<Person> People { get; set; } = null!;
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public string? Search { get; set; }
    }
}