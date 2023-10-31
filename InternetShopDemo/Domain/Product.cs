public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int CategoryID { get; set; }
    public Category Category { get; set; }
    public int ManufacturerID { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public Warehouse Warehouse { get; set; }
    public ICollection<Order> Orders { get; set; }
}
