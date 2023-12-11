from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from models import Base

db_url = 'postgresql://postgres:1@localhost:5432/postgres'

engine = create_engine(db_url)

SessionLocal = sessionmaker(bind=engine)

session = SessionLocal()

Base.metadata.create_all(engine)