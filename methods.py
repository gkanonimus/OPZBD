from sqlalchemy.orm import Session
from models import Manufacturer, Category, Product, Warehouse, Order

class BaseRepository:
    def __init__(self, session, model):
        self.session = session
        self.model = model

    def create(self, **kwargs):
        entity = self.model(**kwargs)
        self.session.add(entity)
        self.session.commit()
        return entity

    def get(self, record_id: int):
        primary_key = self.model.__mapper__.primary_key[0]
        return self.session.query(self.model).filter(primary_key == record_id).first()

    def update(self, record_id: int, **kwargs):
        record = self.get(record_id)
        for key, value in kwargs.items():
            setattr(record, key, value)
        self.session.commit()

    def delete(self, record_id: int):
        record = self.get(record_id)
        self.session.delete(record)
        self.session.commit()
