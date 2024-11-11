namespace SalesReport.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
    public int UnitsSold { get; set; }


    public decimal CalculateRevenue(List<Product> products)
    {
        return products.Sum(p => p.Price * p.UnitsSold);
    }

}