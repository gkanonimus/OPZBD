import pytest
from models import Order, Product
from datetime import datetime

@pytest.fixture(scope='function')
def add_order_data(session, add_test_data):
    _, _, new_product = add_test_data

    new_order = Order(ProductID=new_product.ProductID, Quantity=5, OrderDate=datetime.now())
    session.add(new_order)
    session.commit()

    yield new_order

    session.delete(new_order)
    session.commit()

def test_create_order(session, add_order_data):
    new_order = add_order_data
    assert new_order.OrderID is not None

def test_read_order(session, add_order_data):
    new_order = add_order_data
    found_order = session.query(Order).filter_by(OrderID=new_order.OrderID).first()
    assert found_order is not None
    assert found_order.ProductID == new_order.ProductID

def test_update_order(session, add_order_data):
    new_order = add_order_data
    new_order.Quantity = 10
    session.commit()

    updated_order = session.query(Order).filter_by(OrderID=new_order.OrderID).first()
    assert updated_order.Quantity == 10

def test_delete_order(session, add_order_data):
    new_order = add_order_data

    session.delete(new_order)
    session.commit()

    deleted_order = session.query(Order).filter_by(OrderID=new_order.OrderID).first()
    assert deleted_order is None