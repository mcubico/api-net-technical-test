using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ArandaTechnicalTest.Presentation.Models
{
    public class QueryParametersPagination
    {
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 5;
    }
}
