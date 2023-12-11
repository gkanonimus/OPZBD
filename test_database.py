import pytest
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from database import SessionLocal, engine
from models import Base

@pytest.fixture(scope="module")
def database_engine():
    return create_engine('postgresql://postgres:1@localhost:5432/postgres')

@pytest.fixture(scope="module")
def session(database_engine):
    Base.metadata.create_all(database_engine)
    SessionLocal = sessionmaker(bind=database_engine)
    return SessionLocal()

def test_database_connection(database_engine):
    assert database_engine.connect() != None, "Database connection failed"

def test_session_creation(session):
    assert session != None, "Session creation failed"

def test_create_tables(session):
    assert len(Base.metadata.tables) > 0, "No tables created"