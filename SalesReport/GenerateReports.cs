using SalesReport.Interfaces;
using SalesReport.Models;

namespace SalesReport;

public class GenerateReports
{
    public void ReportSetup(IDatabase db, FileWriter fileWriter)
    {
        var products = db.GetAllProducts();
        var categories = db.GetAllCategories();
        
        GenerateReport(products, categories, fileWriter);
    }

    public decimal CalculateRevenue(List<Product> products)
    {
        return products.Sum(p => p.Price * p.UnitsSold);
    }

    public void GenerateReport(List<Product> products, List<Category> categories, FileWriter fileWriter)
    {
        foreach (var category in categories)
        {
            var categoryName = category.Name;
            var categoryProducts = category.GetCategoryProducts(products);
            var totalRevenue = CalculateRevenue(categoryProducts);
            
            var reportContent = $"Category: {categoryName}\nTotal Revenue: {totalRevenue}:-\n\nProducts:\n";

            foreach (var product in categoryProducts)
            {
                reportContent += $"- {product.Name}: {product.UnitsSold} units sold, revenue: {product.Price * product.UnitsSold}\n";
            }

            fileWriter.WriteToFile($"report_{categoryName}.txt", reportContent);
            
        }
    }

    
}