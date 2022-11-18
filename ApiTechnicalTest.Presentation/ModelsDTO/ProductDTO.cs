using ApiTechnicalTest.Presentation.ModelsDTO;

namespace ArandaTechnicalTest.Presentation.ModelsDTO
{
    public class ProductDTO : ProductCreationDTO
    {
        public Guid Id { get; set; }

        public CategoryDTO Category { get; set; }
    }
}
