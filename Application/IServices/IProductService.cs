namespace Application.IServices
{
    public interface IProductService
    {
        public List<ProductDto> GetAllProducts();
        public ProductDto GetProductById(int id);
        public bool UpdateProduct(ProductDto product);
        public bool DeleteProduct(int id);
    }
}
