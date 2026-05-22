using UESAN.SHOPPING.CORE.Core.Entities;

namespace UESAN.SHOPPING.CORE.Core.Interfaces
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task DeleteProduct(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task UpdateProduct(Product product);
    }
}
