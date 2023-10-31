public class OrderMap : EntityTypeConfiguration<Order>
{
    public OrderMap()
    {
        // Primary Key
        this.HasKey(t => t.OrderID);

        // Properties
        this.Property(t => t.Quantity)
            .IsRequired();

        // Table & Column Mappings
        this.ToTable("Orders");
        this.Property(t => t.OrderID).HasColumnName("OrderID");
        this.Property(t => t.ProductID).HasColumnName("ProductID");
        this.Property(t => t.Quantity).HasColumnName("Quantity");
        this.Property(t => t.OrderDate).HasColumnName("OrderDate");

        // Relationships
        this.HasRequired(t => t.Product)
            .WithMany()
            .HasForeignKey(d => d.ProductID);
    }
}
