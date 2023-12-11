import pytest
from models import Manufacturer
from database import session

@pytest.fixture(scope="module")
def new_manufacturer():
    manufacturer = Manufacturer(ManufacturerName="Sony", Country="Japan")
    return manufacturer

def test_new_manufacturer(new_manufacturer):
    assert new_manufacturer.ManufacturerName == "Sony", "Incorrect manufacturer name"
    assert new_manufacturer.Country == "Japan", "Incorrect country"

def test_add_manufacturer(session, new_manufacturer):
    session.add(new_manufacturer)
    session.commit()
    assert new_manufacturer in session, "Manufacturer not added to session"

def test_get_manufacturer(session, add_test_data):
    new_manufacturer, new_category, _ = add_test_data
    manufacturer = session.query(Manufacturer).filter_by(ManufacturerName="Sony").first()
    assert manufacturer == new_manufacturer, "Manufacturer retrieval failed"