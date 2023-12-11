import pytest
from models import Category
from database import session

@pytest.fixture(scope="module")
def new_category():
    category = Category(CategoryName="Electronics")
    return category

def test_new_category(new_category):
    assert new_category.CategoryName == "Electronics", "Incorrect category name"

def test_add_category(session, new_category):
    session.add(new_category)
    session.commit()
    assert new_category in session, "Category not added to session"

def test_get_category(session, add_test_data):
    new_manufacturer, new_category, _ = add_test_data
    category = session.query(Category).filter_by(CategoryName="Electronics").first()
    assert category == new_category, "Category retrieval failed"
