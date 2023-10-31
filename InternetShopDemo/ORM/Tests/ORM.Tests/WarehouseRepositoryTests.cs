using NUnit.Framework;
using InternetShopDemo.Domain;
using InternetShopDemo.ORM.Repositories;

namespace InternetShopDemo.Tests
{
    [TestFixture]
    public class WarehouseRepositoryTests
    {
        private WarehouseRepository _repository;
        private Warehouse _warehouse;

        [SetUp]
        public void Setup()
        {
            _repository = new WarehouseRepository(/* параметры для инициализации репозитория */);
            _warehouse = new Warehouse
            {
                ProductID = 1,
                Quantity = 100,
                LastStockUpdate = DateTime.Now
            };
        }

        [Test]
        public void CreateTest()
        {
            _repository.Create(_warehouse);
            var result = _repository.GetById(_warehouse.ProductID);
            Assert.IsNotNull(result);
            Assert.AreEqual(_warehouse.Quantity, result.Quantity);
        }

        [Test]
        public void UpdateTest()
        {
            _repository.Create(_warehouse);
            _warehouse.Quantity = 150;
            _repository.Update(_warehouse);
            var result = _repository.GetById(_warehouse.ProductID);
            Assert.IsNotNull(result);
            Assert.AreEqual(150, result.Quantity);
        }

        [Test]
        public void DeleteTest()
        {
            _repository.Create(_warehouse);
            _repository.Delete(_warehouse);
            var result = _repository.GetById(_warehouse.ProductID);
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllTest()
        {
            _repository.Create(_warehouse);
            var result = _repository.GetAll();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
