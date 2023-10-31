public class ManufacturerMap : EntityTypeConfiguration<Manufacturer>
{
    public ManufacturerMap()
    {
        // Primary Key
        this.HasKey(t => t.ManufacturerID);

        // Properties
        this.Property(t => t.ManufacturerName)
            .IsRequired()
            .HasMaxLength(50);

        this.Property(t => t.Country)
            .IsRequired()
            .HasMaxLength(50);

        // Table & Column Mappings
        this.ToTable("Manufacturers");
        this.Property(t => t.ManufacturerID).HasColumnName("ManufacturerID");
        this.Property(t => t.ManufacturerName).HasColumnName("ManufacturerName");
        this.Property(t => t.Country).HasColumnName("Country");

        // Relationships
        this.HasMany(t => t.Products)
            .WithRequired(t => t.Manufacturer)
            .HasForeignKey(d => d.ManufacturerID);
    }
}
