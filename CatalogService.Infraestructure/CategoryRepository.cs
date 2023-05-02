using System.Collections.Generic;
using System.Linq;
using CatalogService.Application;
using CatalogService.Domain;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infraestructure
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Persistence.ApplicationDBContext _applicationDB;
        public CategoryRepository(Persistence.ApplicationDBContext applicationDB)
        {
            _applicationDB = applicationDB;
        }

        public List<Category> GetAllCategories()
        {
            using (var db = _applicationDB)
            {
                var cat = db.Category.ToList();
                return cat;

            } 
        }

        public Category GetCategory(string name)
        {
            using (var db = _applicationDB)
            {
                var cat = db.Category
                    .Where(n => n.Name == name)
                    .FirstOrDefault();

                return cat;

            }
        }

        public int AddCategory(Category category)
        {
            using (var db = _applicationDB)
            {
                db.Category.Add(category);
                return db.SaveChanges();

            }
        }

        public int UpdateCategory(string nameToFind, Category category)
        {
            using (var db = _applicationDB)
            {
                var c = db.Category.Find(nameToFind);
                c.Name = category.Name;
                c.Image = category.Image;
                return db.SaveChanges();
            }
        }

        public int DeleteCategory(string nameToFind)
        {
            using (var db = _applicationDB)
            {
                var c = db.Category.Find(nameToFind);
                db.Attach(c);
                db.Remove(c);
                return db.SaveChanges();
            }
        }

        public List<Item> GetAllItems()
        {
            using (var db = _applicationDB)
            {
                var itm = db.Item.ToList();

                foreach (var i in itm)
                {
                    Category _category = GetCategory(i.Name);
                    i.Category = _category;
                }

                return itm;

            }
        }

        public Item GetItem(string nameItem)
        {
            using (var db = _applicationDB)
            {
                var itm = db.Item
                    .Where(n => n.NameItem == nameItem)
                    .FirstOrDefault();

                var cat = db.Category
                    .Where(n => n.Name == itm.Name)
                    .FirstOrDefault();

                itm.Category = cat;

                return itm;

            }
        }


        public int AddItem(Item item)
        {
            using (var db = _applicationDB)
            {
                Category c = db.Category.First(n => n.Name == item.Name);

                item.Category = c;

                db.Item.Add(item);
                return db.SaveChanges();

            }
        }

        public int UpdateItem(string nameToFind, Item item)
        {
            using (var db = _applicationDB)
            {
                var i = db.Item.Find(nameToFind);
                i.NameItem = item.NameItem;
                i.Description= item.Description;
                i.Image = item.Image;
                i.Price = item.Price;
                i.Amount = item.Amount;

                i.Name = item.Name;


                return db.SaveChanges();
            }
        }

        public int DeleteItem(string nameToFind)
        {
            using (var db = _applicationDB)
            {
                var i = db.Item.Find(nameToFind);
                db.Attach(i);
                db.Remove(i);
                return db.SaveChanges();
            }
        }

    }
}
