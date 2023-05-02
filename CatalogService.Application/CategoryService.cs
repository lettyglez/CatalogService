using System;
using System.Collections.Generic;
using System.Text;
using CatalogService.Domain;

namespace CatalogService.Application
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public List<Category> GetAllCategories()
        {
            return this.categoryRepository.GetAllCategories();
        }

        public Category GetCategory(string name)
        {
            return this.categoryRepository.GetCategory(name);
        }

        public int AddCategory(Category category)
        {
            return this.categoryRepository.AddCategory(category);
        }

        public int UpdateCategory(string nameToFind, Category category)
        {
            return this.categoryRepository.UpdateCategory(nameToFind, category);
        }

        public int DeleteCategory(string nameToFind)
        {
            return this.categoryRepository.DeleteCategory(nameToFind);
        }

        public int AddItem(Item item)
        {
            return this.categoryRepository.AddItem(item);
        }

        public List<Item> GetAllItems()
        {
            return this.categoryRepository.GetAllItems();
        }

        public Item GetItem(string nameItem)
        {
            return this.categoryRepository.GetItem(nameItem);
        }

        public int UpdateItem(string nameToFind, Item item)
        {
            return this.categoryRepository.UpdateItem(nameToFind, item);
        }

        public int DeleteItem(string nameToFind)
        {
            return this.categoryRepository.DeleteItem(nameToFind);
        }
    }
}
