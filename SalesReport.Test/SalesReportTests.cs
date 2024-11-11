using SalesReport;
using SalesReport.Models;


namespace SalesReportTest;

public class SalesReportTests
{
    [Fact]
    public void TestToSeeIfWriteToFilePrintsCorrectly()
    {
        // Arrange
        var sutReport = new GenerateReports();
        var sutFilewriter = new FileWriter();
        
        var categories = new List<Category>()
        {
            new Category(){Id = 1, Name = "Category A"}
        };
    
        var categoryProducts = new List<Product>()
        {
            new Product() { Id = 1, CategoryId = 1, Name = "Product A", Price = decimal.Parse("12,5"), UnitsSold = 2 }
        };
        var expected = $"Writing to file 'report_Category A.txt':\nCategory: Category A\nTotal Revenue: 25,0:-\n\nProducts:\n"
            + $"- Product A: 2 units sold, revenue: 25,0\n";

        using (var consoleOutput = new StringWriter())
        {
            Console.SetOut(consoleOutput);
            // Act
            sutReport.GenerateReport(categoryProducts, categories, sutFilewriter);
            
            var outputtt = consoleOutput.ToString();
            // Assert
            Assert.Contains(expected, outputtt);
        }
    }
    [Fact]
    public void TestToGetAllProducts()
    {
        List<Product> products = new List<Product>()
        {
            new Product(){Id = 1, Name = "Choklad", CategoryId = 1, Price = 12.5m, UnitsSold = 20},
            new Product(){Id = 2, Name = "Karamell", CategoryId = 1, Price = 7.90m, UnitsSold = 12},
            new Product(){Id = 3, Name = "Vingummi", CategoryId = 1, Price = 19.90m, UnitsSold = 10}
        };
        var sut = new ProductRepository(products);
        var actual = sut.GetAllProducts();
        
        Assert.Equal(products, actual);
    }
    [Theory]
    [MemberData(nameof(ProductListTestData))]
    public void TestToSeeIfReturnProductsIfValueIsNull(List<Product> products)
    {
        Assert.ThrowsAny<ArgumentNullException>(() => new ProductRepository(products));
    }

    public static IEnumerable<object[]> ProductListTestData()
    {
        yield return new object[]
        {
            new List<Product>()
            {
                new Product() { Id = 1, CategoryId = 2, UnitsSold = 5, Name = null, Price = 9.90m },
                new Product() { Id = 2, CategoryId = 2, UnitsSold = 10, Name = "Spenat", Price = 9.90m },
                new Product() { Id = 3, CategoryId = 2, UnitsSold = 15, Name = "Blomkål", Price = 9.90m }
            }
        };

        yield return new object[]
        {
            new List<Product>()
            {
                new Product() { Id = 4, CategoryId = 1, UnitsSold = 5, Name = "Grädde", Price = 9.90m },
                new Product() { Id = 5, CategoryId = 1, UnitsSold = 10, Name = null, Price = 9.90m },
                new Product() { Id = 6, CategoryId = 2, UnitsSold = 15, Name = "Broccoli", Price = 9.90m }
            }
        };
        yield return new object[]
        {
            new List<Product>()
            {
                new Product() { Id = 7, CategoryId = 3, UnitsSold = 5, Name = "Choklad", Price = 9.90m },
                new Product() { Id = 8, CategoryId = 3, UnitsSold = 10, Name = "Polkagris", Price = 9.90m },
                new Product() { Id = 9, CategoryId = 3, UnitsSold = 15, Name = null, Price = 9.90m }
            }
        };
    }
}
