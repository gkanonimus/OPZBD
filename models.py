import sqlalchemy.orm
from sqlalchemy import Column, Integer, String, Date, ForeignKey
from sqlalchemy.orm import relationship
from sqlalchemy.ext.declarative import declarative_base

Base = sqlalchemy.orm.declarative_base()

class Manufacturer(Base):
    __tablename__ = 'Manufacturers'
    ManufacturerID = Column(Integer, primary_key=True)
    ManufacturerName = Column(String(50), nullable=False)
    Country = Column(String(50), nullable=False)

class Category(Base):
    __tablename__ = 'Categories'
    CategoryID = Column(Integer, primary_key=True)
    CategoryName = Column(String(50), nullable=False)

class Product(Base):
    __tablename__ = 'Products'
    __mapper_args__ = {
        'confirm_deleted_rows': False
    }
    ProductID = Column(Integer, primary_key=True)
    ProductName = Column(String(100), nullable=False)
    CategoryID = Column(Integer, ForeignKey('Categories.CategoryID'))
    ManufacturerID = Column(Integer, ForeignKey('Manufacturers.ManufacturerID'))
    Price = Column(Integer, nullable=False)
    Quantity = Column(Integer, nullable=False)
    category = relationship("Category")
    manufacturer = relationship("Manufacturer")

class Warehouse(Base):
    __tablename__ = 'Warehouse'
    __mapper_args__ = {
        'confirm_deleted_rows': False
    }
    OrderID = Column(Integer, primary_key=True)
    ProductID = Column(Integer, ForeignKey('Products.ProductID'))
    Quantity = Column(Integer, nullable=False)
    LastStockUpdate = Column(Date, nullable=False)
    product = relationship("Product")

class Order(Base):
    __tablename__ = 'Orders'
    __mapper_args__ = {
        'confirm_deleted_rows': False
    }
    OrderID = Column(Integer, primary_key=True)
    ProductID = Column(Integer, ForeignKey('Products.ProductID'))
    Quantity = Column(Integer, nullable=False)
    OrderDate = Column(Date, nullable=False)
    product = relationship("Product")