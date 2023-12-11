import pytest
from models import Manufacturer, Category, Product, Warehouse, Order

def test_create_manufacturer(session):
    manufacturer = Manufacturer(ManufacturerName="TestManufacturer", Country="TestCountry")
    session.add(manufacturer)
    session.commit()
    assert manufacturer in session

def test_create_category(session):
    category = Category(CategoryName="TestCategory")
    session.add(category)
    session.commit()
    assert category in session

def test_create_product(session, add_test_data):
    new_manufacturer, new_category, _ = add_test_data
    product = Product(ProductName="TestProduct", CategoryID=new_category.CategoryID, ManufacturerID=new_manufacturer.ManufacturerID, Price=100, Quantity=10)
    session.add(product)
    session.commit()
    assert product in session and product.category == new_category and product.manufacturer == new_manufacturer

def test_create_warehouse(session, add_test_data):
    new_manufacturer, new_category, new_product = add_test_data
    warehouse = Warehouse(ProductID=new_product.ProductID, Quantity=20, LastStockUpdate="2023-01-01")
    session.add(warehouse)
    session.commit()
    assert warehouse in session

def test_create_order(session, add_test_data):
    new_manufacturer, new_category, new_product = add_test_data
    order = Order(ProductID=new_product.ProductID, Quantity=5, OrderDate="2023-01-01")
    session.add(order)
    session.commit()
    assert order in session