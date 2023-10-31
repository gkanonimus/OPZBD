using NUnit.Framework;
using InternetShopDemo.Domain;
using InternetShopDemo.ORM.Repositories;

namespace InternetShopDemo.Tests
{
    [TestFixture]
    public class ManufacturerRepositoryTests
    {
        private ManufacturerRepository _repository;
        private Manufacturer _manufacturer;

        [SetUp]
        public void Setup()
        {
            _repository = new ManufacturerRepository(/* параметры для инициализации репозитория */);
            _manufacturer = new Manufacturer
            {
                ManufacturerName = "TestManufacturer",
                Country = "TestCountry"
            };
        }

        [Test]
        public void CreateTest()
        {
            _repository.Create(_manufacturer);
            var result = _repository.GetById(_manufacturer.ManufacturerID);
            Assert.IsNotNull(result);
            Assert.AreEqual(_manufacturer.ManufacturerName, result.ManufacturerName);
        }

        [Test]
        public void UpdateTest()
        {
            _repository.Create(_manufacturer);
            _manufacturer.ManufacturerName = "UpdatedManufacturer";
            _repository.Update(_manufacturer);
            var result = _repository.GetById(_manufacturer.ManufacturerID);
            Assert.IsNotNull(result);
            Assert.AreEqual("UpdatedManufacturer", result.ManufacturerName);
        }

        [Test]
        public void DeleteTest()
        {
            _repository.Create(_manufacturer);
            _repository.Delete(_manufacturer);
            var result = _repository.GetById(_manufacturer.ManufacturerID);
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllTest()
        {
            _repository.Create(_manufacturer);
            var result = _repository.GetAll();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
