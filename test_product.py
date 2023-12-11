import pytest
from models import Product

def test_create_product(session, add_test_data):
    new_manufacturer, new_category, _ = add_test_data
    new_product = Product(ProductName="NewProduct", CategoryID=new_category.CategoryID, ManufacturerID=new_manufacturer.ManufacturerID, Price=200, Quantity=15)
    session.add(new_product)
    session.commit()

    assert new_product.ProductID is not None

def test_read_product(session, add_test_data):
    _, _, new_product = add_test_data
    product = session.query(Product).filter_by(ProductID=new_product.ProductID).first()

    assert product is not None
    assert product.ProductName == new_product.ProductName

def test_update_product(session, add_test_data):
    _, _, new_product = add_test_data
    product = session.query(Product).filter_by(ProductID=new_product.ProductID).first()
    product.Quantity = 20
    session.commit()

    updated_product = session.query(Product).filter_by(ProductID=new_product.ProductID).first()
    assert updated_product.Quantity == 20

def test_delete_product(session, add_test_data):
    _, _, new_product = add_test_data
    session.delete(new_product)
    session.commit()

    deleted_product = session.query(Product).filter_by(ProductID=new_product.ProductID).first()
    assert deleted_product is None