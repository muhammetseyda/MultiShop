using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Dtos.ProductImageDtos
{
    public class UpdateProductImageDto
    {
        public string ProductImageId { get; set; }
        public string ProductImage1 { get; set; }
        public string ProductImage2 { get; set; }
        public string ProductImage3 { get; set; }
        public string ProductId { get; set; }
    }
}
