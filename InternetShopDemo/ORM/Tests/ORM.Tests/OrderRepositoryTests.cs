using NUnit.Framework;
using InternetShopDemo.Domain;
using InternetShopDemo.ORM.Repositories;

namespace InternetShopDemo.Tests
{
    [TestFixture]
    public class OrderRepositoryTests
    {
        private OrderRepository _repository;
        private Order _order;

        [SetUp]
        public void Setup()
        {
            _repository = new OrderRepository(/* параметры для инициализации репозитория */);
            _order = new Order
            {
                ProductID = 1,
                Quantity = 5,
                OrderDate = DateTime.Now
            };
        }

        [Test]
        public void CreateTest()
        {
            _repository.Create(_order);
            var result = _repository.GetById(_order.OrderID);
            Assert.IsNotNull(result);
            Assert.AreEqual(_order.ProductID, result.ProductID);
        }

        [Test]
        public void UpdateTest()
        {
            _repository.Create(_order);
            _order.Quantity = 10;
            _repository.Update(_order);
            var result = _repository.GetById(_order.OrderID);
            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Quantity);
        }

        [Test]
        public void DeleteTest()
        {
            _repository.Create(_order);
            _repository.Delete(_order);
            var result = _repository.GetById(_order.OrderID);
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllTest()
        {
            _repository.Create(_order);
            var result = _repository.GetAll();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
