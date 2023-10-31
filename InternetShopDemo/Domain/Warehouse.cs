public class Warehouse
{
    public int ProductID { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public DateTime LastStockUpdate { get; set; }
}
