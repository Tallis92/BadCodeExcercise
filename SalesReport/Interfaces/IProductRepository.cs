using SalesReport.Models;

namespace SalesReport.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
    }
}

