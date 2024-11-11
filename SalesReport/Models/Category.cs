namespace SalesReport.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    
 
    public List<Product> GetCategoryProducts(List<Product> products)
    {
        return products.Where(p => p.CategoryId == Id).ToList();
    }
}