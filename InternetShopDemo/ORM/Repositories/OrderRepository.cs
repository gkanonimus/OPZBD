public class OrderRepository : IRepository<Order>
{
    private readonly DbContext _context;

    public OrderRepository(DbContext context)
    {
        _context = context;
    }

    public void Create(Order entity)
    {
        _context.Set<Order>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(Order entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(Order entity)
    {
        _context.Set<Order>().Remove(entity);
        _context.SaveChanges();
    }

    public Order GetById(int id)
    {
        return _context.Set<Order>().Find(id);
    }

    public List<Order> GetAll()
    {
        return _context.Set<Order>().ToList();
    }
}
