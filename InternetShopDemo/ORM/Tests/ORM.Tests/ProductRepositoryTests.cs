using NUnit.Framework;
using InternetShopDemo.Domain;
using InternetShopDemo.ORM.Repositories;

namespace InternetShopDemo.Tests
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private ProductRepository _repository;
        private Product _product;

        [SetUp]
        public void Setup()
        {
            // Инициализация контекста базы данных и репозитория
            _repository = new ProductRepository(/* параметры для инициализации репозитория */);
            _product = new Product
            {
                ProductName = "TestProduct",
                CategoryID = 1,
                ManufacturerID = 1,
                Price = 100,
                Quantity = 10
            };
        }

        [Test]
        public void CreateTest()
        {
            _repository.Create(_product);
            var result = _repository.GetById(_product.ProductID);
            Assert.IsNotNull(result);
            Assert.AreEqual(_product.ProductName, result.ProductName);
        }

        [Test]
        public void UpdateTest()
        {
            _repository.Create(_product);
            _product.ProductName = "UpdatedProduct";
            _repository.Update(_product);
            var result = _repository.GetById(_product.ProductID);
            Assert.IsNotNull(result);
            Assert.AreEqual("UpdatedProduct", result.ProductName);
        }

        [Test]
        public void DeleteTest()
        {
            _repository.Create(_product);
            _repository.Delete(_product);
            var result = _repository.GetById(_product.ProductID);
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllTest()
        {
            _repository.Create(_product);
            var result = _repository.GetAll();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
