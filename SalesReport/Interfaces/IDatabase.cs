using SalesReport.Models;

namespace SalesReport.Interfaces
{
    public interface IDatabase
    {
        List<Product> GetAllProducts();
        List<Category> GetAllCategories();
    } 
}

