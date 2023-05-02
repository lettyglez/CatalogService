using System;
using System.Collections.Generic;
using System.Text;
using CatalogService.Domain;

namespace CatalogService.Application
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category GetCategory(string name);
        int AddCategory(Category category);
        int UpdateCategory(string nameToFind, Category category);
        int DeleteCategory(string nameToFind);
        int AddItem(Item item);
        List<Item> GetAllItems();
        Item GetItem(string nameItem);
        int UpdateItem(string nameToFind, Item item);
        int DeleteItem(string nameToFind);
    }
}
