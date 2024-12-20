using Microsoft.EntityFrameworkCore;

namespace StoreApp.Data.Concrete;

public class StoreDbContext:DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categries => Set<Category>();

    public DbSet<Order> Orders => Set<Order>();
    // public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
                    .HasMany(e => e.Categories)
                    .WithMany(e => e.Products)
                    .UsingEntity<ProductCategory>();
        
        modelBuilder.Entity<Category>()//  kategorinin url alanı tekil bir veri oldu
                    .HasIndex(e => e.Url)
                    .IsUnique();

        modelBuilder.Entity<Product>().HasData(
            new List<Product>() {
                new() { Id=1, Name="Samsung S24", Price=50000, Description="güzel telefon" },
                new() { Id=2, Name="Bulasik Makinasi", Price=60000, Description="güzel Bulasik Makinasi" },
                new() { Id=3, Name="Tost Makinasi", Price=70000, Description="güzel Tost" },
                new() { Id=4, Name="Iphone 16", Price=80000, Description="güzel telefon" },
                new() { Id=5, Name="Firin", Price=90000, Description="güzel Firin" },
                new() { Id=6, Name="Buz Dolabi", Price=100000, Description="güzel Buz Dolabi" },
                new() { Id=7, Name="Blender", Price=100000, Description="güzel Blender" },
                new() { Id=8, Name="Laptop", Price=30000, Description="güzel laptop" },
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new List<Category>() {
                new() { Id=1, Name="Telefon" ,Url="telefon"},
                new() { Id=2, Name="Elektronik" ,Url="elektronik"},
                new() { Id=3, Name="Beyaz Eşya" ,Url="beyaz-esya"}
            });


        modelBuilder.Entity<ProductCategory>().HasData(
            new List<ProductCategory>(){
                new ProductCategory() { ProductId = 1, CategoryId=1},
                new ProductCategory() { ProductId = 2, CategoryId=3},
                new ProductCategory() { ProductId = 3, CategoryId=2},
                new ProductCategory() { ProductId = 4, CategoryId=1},
                new ProductCategory() { ProductId = 5, CategoryId=2},
                new ProductCategory() { ProductId = 6, CategoryId=3},
                new ProductCategory() { ProductId = 7, CategoryId=2},
                new ProductCategory() { ProductId = 8, CategoryId=2}

            }
        );
    }
}