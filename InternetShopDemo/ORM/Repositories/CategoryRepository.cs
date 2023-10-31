public class CategoryRepository : IRepository<Category>
{
    private readonly DbContext _context;

    public CategoryRepository(DbContext context)
    {
        _context = context;
    }

    public void Create(Category entity)
    {
        _context.Set<Category>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(Category entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(Category entity)
    {
        _context.Set<Category>().Remove(entity);
        _context.SaveChanges();
    }

    public Category GetById(int id)
    {
        return _context.Set<Category>().Find(id);
    }

    public List<Category> GetAll()
    {
        return _context.Set<Category>().ToList();
    }
}
