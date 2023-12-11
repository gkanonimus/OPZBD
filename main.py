from database import session as db_session
from methods import BaseRepository
from models import Manufacturer, Category, Product, Warehouse, Order

manufacturer_repository = BaseRepository(db_session, Manufacturer)
category_repository = BaseRepository(db_session, Category)
product_repository = BaseRepository(db_session, Product)
warehouse_repository = BaseRepository(db_session, Warehouse)
order_repository = BaseRepository(db_session, Order)
