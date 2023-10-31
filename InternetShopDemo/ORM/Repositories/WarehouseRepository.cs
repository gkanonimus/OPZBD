public class WarehouseRepository : IRepository<Warehouse>
{
    private readonly DbContext _context;

    public WarehouseRepository(DbContext context)
    {
        _context = context;
    }

    public void Create(Warehouse entity)
    {
        _context.Set<Warehouse>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(Warehouse entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(Warehouse entity)
    {
        _context.Set<Warehouse>().Remove(entity);
        _context.SaveChanges();
    }

    public Warehouse GetById(int id)
    {
        return _context.Set<Warehouse>().Find(id);
    }

    public List<Warehouse> GetAll()
    {
        return _context.Set<Warehouse>().ToList();
    }
}
