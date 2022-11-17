using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechnicalTest.Data.Entities
{
    public class OrderDetailEntity
    {
        #region PROPERTIES

        [Required]
        public int Quantity { get; set; } = 0;

        [Required]
        public decimal UnitPrice { get; set; } = 0;

        public int? Discount { get; set; }

        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        #endregion

        #region FOREING KEY

        [ForeignKey(nameof(OrderId))]
        public OrderEntity Order { get; set; }

        [ForeignKey(nameof(ProductId))]
        public ProductEntity Product { get; set; }

        #endregion
    }
}
