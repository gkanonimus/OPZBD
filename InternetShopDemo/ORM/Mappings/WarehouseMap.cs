public class WarehouseMap : EntityTypeConfiguration<Warehouse>
{
    public WarehouseMap()
    {
        // Primary Key
        this.HasKey(t => t.ProductID);

        // Properties
        this.Property(t => t.Quantity)
            .IsRequired();

        // Table & Column Mappings
        this.ToTable("Warehouse");
        this.Property(t => t.ProductID).HasColumnName("ProductID");
        this.Property(t => t.Quantity).HasColumnName("Quantity");
        this.Property(t => t.LastStockUpdate).HasColumnName("LastStockUpdate");

        // Relationships
        this.HasRequired(t => t.Product)
            .WithOptional(t => t.Warehouse);
    }
}
