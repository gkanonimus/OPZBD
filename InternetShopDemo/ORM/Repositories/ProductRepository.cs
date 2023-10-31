public class ProductRepository : IRepository<Product>
{
    private readonly DbContext _context;

    public ProductRepository(DbContext context)
    {
        _context = context;
    }

    public void Create(Product entity)
    {
        _context.Set<Product>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(Product entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(Product entity)
    {
        _context.Set<Product>().Remove(entity);
        _context.SaveChanges();
    }

    public Product GetById(int id)
    {
        return _context.Set<Product>().Find(id);
    }

    public List<Product> GetAll()
    {
        return _context.Set<Product>().ToList();
    }
}
