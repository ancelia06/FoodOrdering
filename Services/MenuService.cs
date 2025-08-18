using FoodOrdering__API.Data;
using FoodOrdering__API.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering__API.Services
{
    public class MenuService : IMenuService
    {
        private readonly AppDbContext _db;
        public MenuService(AppDbContext db) => _db = db;

        public List<FoodItem> GetMenu() =>
            _db.FoodItems.AsNoTracking().OrderBy(f => f.Id).ToList();

        public FoodItem AddMenu(FoodItem item)
        {
            _db.FoodItems.Add(item);
            _db.SaveChanges();
            return item;
        }

        public bool UpdateMenu(int id, FoodItem updatedItem)
        {
            var existing = _db.FoodItems.Find(id);
            if (existing is null) return false;
            existing.Name = updatedItem.Name;
            existing.Price = updatedItem.Price;
            _db.SaveChanges();
            return true;
        }

        public bool DeleteMenu(int id)
        {
            var existing = _db.FoodItems.Find(id);
            if (existing is null) return false;
            _db.FoodItems.Remove(existing);
            _db.SaveChanges();
            return true;
        }
    }
}
