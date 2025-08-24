namespace Domain.Common
{
    public class FilterOption
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 2;
        public string OrderBy { get; set; } = "Id";
        public string Order { get; set; } = "ASC";
        public string? Search { get; set; }
    }
}

