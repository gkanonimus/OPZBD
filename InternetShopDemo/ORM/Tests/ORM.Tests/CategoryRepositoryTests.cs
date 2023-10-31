using NUnit.Framework;
using InternetShopDemo.Domain;
using InternetShopDemo.ORM.Repositories;

namespace InternetShopDemo.Tests
{
    [TestFixture]
    public class CategoryRepositoryTests
    {
        private CategoryRepository _repository;
        private Category _category;

        [SetUp]
        public void Setup()
        {
            _repository = new CategoryRepository(/* параметры для инициализации репозитория */);
            _category = new Category
            {
                CategoryName = "TestCategory"
            };
        }

        [Test]
        public void CreateTest()
        {
            _repository.Create(_category);
            var result = _repository.GetById(_category.CategoryID);
            Assert.IsNotNull(result);
            Assert.AreEqual(_category.CategoryName, result.CategoryName);
        }

        [Test]
        public void UpdateTest()
        {
            _repository.Create(_category);
            _category.CategoryName = "UpdatedCategory";
            _repository.Update(_category);
            var result = _repository.GetById(_category.CategoryID);
            Assert.IsNotNull(result);
            Assert.AreEqual("UpdatedCategory", result.CategoryName);
        }

        [Test]
        public void DeleteTest()
        {
            _repository.Create(_category);
            _repository.Delete(_category);
            var result = _repository.GetById(_category.CategoryID);
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllTest()
        {
            _repository.Create(_category);
            var result = _repository.GetAll();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
