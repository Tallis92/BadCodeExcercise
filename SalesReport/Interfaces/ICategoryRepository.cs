using SalesReport.Models;

namespace SalesReport.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
    }
}

