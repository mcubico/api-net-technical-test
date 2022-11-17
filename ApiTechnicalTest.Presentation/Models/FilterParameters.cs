namespace ArandaTechnicalTest.Presentation.Models
{
    public class FilterParameters : QueryParametersPagination
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
