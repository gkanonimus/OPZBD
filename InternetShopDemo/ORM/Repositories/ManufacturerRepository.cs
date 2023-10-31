public class ManufacturerRepository : IRepository<Manufacturer>
{
    private readonly DbContext _context;

    public ManufacturerRepository(DbContext context)
    {
        _context = context;
    }

    public void Create(Manufacturer entity)
    {
        _context.Set<Manufacturer>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(Manufacturer entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(Manufacturer entity)
    {
        _context.Set<Manufacturer>().Remove(entity);
        _context.SaveChanges();
    }

    public Manufacturer GetById(int id)
    {
        return _context.Set<Manufacturer>().Find(id);
    }

    public List<Manufacturer> GetAll()
    {
        return _context.Set<Manufacturer>().ToList();
    }
}
