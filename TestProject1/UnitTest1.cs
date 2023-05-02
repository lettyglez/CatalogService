using NUnit.Framework;
using CatalogService.Infraestructure;
using CatalogService.Domain;

namespace TestProject1
{
    public class Tests
    {
        CategoryRepository _categoryRepository;
        CatalogService.Infraestructure.Persistence.ApplicationDBContext _dbContext;

        [SetUp]
        public void Setup()
        {
            _dbContext = new CatalogService.Infraestructure.Persistence.ApplicationDBContext();
            _categoryRepository = new CategoryRepository(_dbContext);
        }

        [Test]
        public void GetAllCategories()
        {
            var c = _categoryRepository.GetAllCategories();
        }

        [Test]
        public void GetCategory()
        {
            string name = "Drinks";
            var c = _categoryRepository.GetCategory(name);
        }

        [Test]
        public void AddCategory()
        {
            Category category = new Category()
            {
                Name = "Drinks",
                Image = "ImageDrink.jpg"
            };

            int result = _categoryRepository.AddCategory(category);
        }

        [Test]
        public void UpdateCategory()
        {
            string nameToFind = "Drinks";
            Category category = new Category()
            {
                Name = "Drinks",
                Image = "www.imageMilk.com"
            };

            int result = _categoryRepository.UpdateCategory(nameToFind, category);
        }

        [Test]
        public void DeleteCategory()
        {
            string nameToFind = "Drinks";

            int result = _categoryRepository.DeleteCategory(nameToFind);
        }

        [Test]
        public void AddItem()
        {
            Item item = new Item()
            {
                NameItem = "Milk",
                Description = "Light",
                Image = "www.MilkLight.com",
                Price = 12.5m,
                Amount = 5,
                Name = "Drinks"
            };

            int result = _categoryRepository.AddItem(item);
        }

        [Test]
        public void GetAllItems()
        {
            var c = _categoryRepository.GetAllItems();
        }

        [Test]
        public void GetItem()
        {
            string nameItem = "Milk";
            var c = _categoryRepository.GetItem(nameItem);
        }

        [Test]
        public void UpdateItem()
        {
            string nameToFind = "Milk";

            Item item = new Item()
            {
                NameItem = "Milk",
                Description = "Almond",
                Image = "www.MilkLight.com",
                Name = "Drinks",
                Price = 18.9m,
                Amount = 4
            };

            int result = _categoryRepository.UpdateItem(nameToFind, item);
        }

        [Test]
        public void DeleteItem()
        {
            string nameToFind = "Milk";

            int result = _categoryRepository.DeleteItem(nameToFind);
        }
    }
}