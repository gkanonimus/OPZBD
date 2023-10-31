public class CategoryMap : EntityTypeConfiguration<Category>
{
    public CategoryMap()
    {
        // Primary Key
        this.HasKey(t => t.CategoryID);

        // Properties
        this.Property(t => t.CategoryName)
            .IsRequired()
            .HasMaxLength(50);

        // Table & Column Mappings
        this.ToTable("Categories");
        this.Property(t => t.CategoryID).HasColumnName("CategoryID");
        this.Property(t => t.CategoryName).HasColumnName("CategoryName");

        // Relationships
        this.HasMany(t => t.Products)
            .WithRequired(t => t.Category)
            .HasForeignKey(d => d.CategoryID);
    }
}
