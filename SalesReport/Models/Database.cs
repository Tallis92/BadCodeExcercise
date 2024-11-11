using SalesReport.Interfaces;

namespace SalesReport.Models;

public class Database : IDatabase
{
    // Let's pretend this actually connects to a database
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public Database(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public List<Product> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }

    public List<Category> GetAllCategories()
    {
        return _categoryRepository.GetAllCategories();
    }
}