using SalesReport.Models;

namespace SalesReport;

public class ProductRepository : Interfaces.IProductRepository
{
    
    // It's of type IEnumerable<Product>, allowing us to provide a collection that is non-modifiable
    // from outside the repository.
    private readonly List<Product> _products;
    
    // If no product list is provided (i.e., null), a default list of products is used.
    public ProductRepository(List<Product>? products = null)
    {
        if (products != null)
        {
            foreach (Product product in products)
            {
                if (product.Name == null)
                {
                    throw new ArgumentNullException(nameof(product.Name),"A product attribute is null");
                }
            }
            _products = products;
        }
        else
        {
            _products = new List<Product>
            {
                new Product(){Id = 1, CategoryId = 1, UnitsSold = 10, Name = "Beb's", Price = decimal.Parse("10,99")},
                new Product(){Id = 2, CategoryId = 1, UnitsSold = 15, Name = "Gregers", Price = decimal.Parse("15,50")},
                new Product(){Id = 3, CategoryId = 1, UnitsSold = 25, Name = "Choko", Price = decimal.Parse("4,99")}
            };
        }
        
    }
   public List<Product> GetAllProducts() => _products;
}

public class CategoryRepository : Interfaces.ICategoryRepository
{
    private readonly List<Category> _categories;

    public CategoryRepository(List<Category>? categories = null)
    {
        _categories = categories ?? new List<Category>
        {
            new Category() { Id = 1, Name = "Groceries" }
        };
    }
    public List<Category> GetAllCategories() => _categories;
}
