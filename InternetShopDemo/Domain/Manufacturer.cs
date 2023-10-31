public class Manufacturer
{
    public int ManufacturerID { get; set; }
    public string ManufacturerName { get; set; }
    public string Country { get; set; }
    public ICollection<Product> Products { get; set; }
}
