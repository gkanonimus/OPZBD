import pytest
from sqlalchemy.orm import scoped_session, sessionmaker
from models import Manufacturer, Category, Product
from methods import BaseRepository
from database import engine, Base

@pytest.fixture(scope='module')
def test_session():
    connection = engine.connect()
    transaction = connection.begin()
    Session = scoped_session(sessionmaker(bind=connection))
    session = Session()
    Base.metadata.create_all(bind=connection)
    yield session
    session.close()
    Base.metadata.drop_all(bind=connection)
    transaction.rollback()
    connection.close()

@pytest.fixture(scope='module')
def manufacturer_repository(test_session):
    return BaseRepository(test_session, Manufacturer)

@pytest.fixture(scope='module')
def category_repository(test_session):
    return BaseRepository(test_session, Category)

@pytest.fixture(scope='module')
def product_repository(test_session):
    return BaseRepository(test_session, Product)

def test_create_manufacturer(manufacturer_repository):
    manufacturer = manufacturer_repository.create(ManufacturerName='Test Manufacturer', Country='Test Country')
    assert manufacturer.ManufacturerName == 'Test Manufacturer'

def test_read_manufacturer(manufacturer_repository):
    manufacturer = manufacturer_repository.create(ManufacturerName='Read Manufacturer', Country='Read Country')
    found = manufacturer_repository.get(manufacturer.ManufacturerID)
    assert found == manufacturer

def test_update_manufacturer(manufacturer_repository):
    manufacturer = manufacturer_repository.create(ManufacturerName='Update Manufacturer', Country='Update Country')
    manufacturer.ManufacturerName = 'Updated Manufacturer'
    manufacturer_repository.session.commit()
    updated = manufacturer_repository.get(manufacturer.ManufacturerID)
    assert updated.ManufacturerName == 'Updated Manufacturer'

def test_delete_manufacturer(manufacturer_repository):
    manufacturer = manufacturer_repository.create(ManufacturerName='Delete Manufacturer', Country='Delete Country')
    manufacturer_id = manufacturer.ManufacturerID
    manufacturer_repository.session.delete(manufacturer)
    manufacturer_repository.session.commit()
    assert manufacturer_repository.get(manufacturer_id) is None