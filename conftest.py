import pytest
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from models import Base, Category, Manufacturer, Order, Product, Warehouse

TEST_DATABASE_URL = 'postgresql://postgres:1@localhost:5432/postgres'

@pytest.fixture(scope='session')
def engine():
    return create_engine(TEST_DATABASE_URL)

@pytest.fixture(scope='session')
def tables(engine):
    Base.metadata.create_all(engine)
    yield
    Base.metadata.drop_all(engine)

@pytest.fixture(scope='function')
def session(engine, tables):
    connection = engine.connect()
    transaction = connection.begin()
    session = sessionmaker(bind=connection)()

    yield session

    session.close()
    transaction.rollback()
    connection.close()

@pytest.fixture(scope='function')
def test_data(session):
    new_manufacturer = Manufacturer(ManufacturerName="Sony", Country="Japan")
    new_category = Category(CategoryName="Electronics")
    session.add(new_manufacturer)
    session.add(new_category)
    session.commit()

    yield

    session.delete(new_manufacturer)
    session.delete(new_category)
    session.commit()

@pytest.fixture(scope='function')
def add_test_data(session):
    new_manufacturer = Manufacturer(ManufacturerName="Sony", Country="Japan")
    new_category = Category(CategoryName="Electronics")
    new_product = Product(ProductName="TestProduct", CategoryID=new_category.CategoryID, ManufacturerID=new_manufacturer.ManufacturerID, Price=100, Quantity=10)

    session.add(new_manufacturer)
    session.add(new_category)
    session.flush()
    session.add(new_product)
    session.commit()

    yield new_manufacturer, new_category, new_product

    session.query(Order).filter(Order.ProductID == new_product.ProductID).delete(synchronize_session=False)
    session.query(Warehouse).filter(Warehouse.ProductID == new_product.ProductID).delete(synchronize_session=False)
    session.flush()

    session.query(Product).filter(Product.CategoryID == new_category.CategoryID).delete(synchronize_session=False)
    session.flush()

    session.delete(new_product)
    session.flush()

    session.delete(new_category)
    session.delete(new_manufacturer)
    session.commit()
