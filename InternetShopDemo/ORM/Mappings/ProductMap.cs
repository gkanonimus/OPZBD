public class ProductMap : EntityTypeConfiguration<Product>
{
    public ProductMap()
    {
        // Primary Key
        this.HasKey(t => t.ProductID);

        // Properties
        this.Property(t => t.ProductName)
            .IsRequired()
            .HasMaxLength(100);

        this.Property(t => t.Price)
            .IsRequired();

        this.Property(t => t.Quantity)
            .IsRequired();

        // Table & Column Mappings
        this.ToTable("Products");
        this.Property(t => t.ProductID).HasColumnName("ProductID");
        this.Property(t => t.ProductName).HasColumnName("ProductName");
        this.Property(t => t.CategoryID).HasColumnName("CategoryID");
        this.Property(t => t.ManufacturerID).HasColumnName("ManufacturerID");
        this.Property(t => t.Price).HasColumnName("Price");
        this.Property(t => t.Quantity).HasColumnName("Quantity");

        // Relationships
        this.HasRequired(t => t.Category)
            .WithMany(t => t.Products)
            .HasForeignKey(d => d.CategoryID);

        this.HasRequired(t => t.Manufacturer)
            .WithMany(t => t.Products)
            .HasForeignKey(d => d.ManufacturerID);
    }
}
