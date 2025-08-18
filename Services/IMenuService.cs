using FoodOrdering__API.Models;

namespace FoodOrdering__API.Services
{
    public interface IMenuService
    {
        List<FoodItem> GetMenu();
        FoodItem AddMenu(FoodItem item);
        bool UpdateMenu(int id, FoodItem updatedItem);
        bool DeleteMenu(int id);
    }
}
