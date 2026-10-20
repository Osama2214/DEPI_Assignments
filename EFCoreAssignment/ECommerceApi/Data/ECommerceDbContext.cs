using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Data;

public class ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
    : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .Property(category => category.Name)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(product => product.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Product>()
            .HasOne(product => product.Category)
            .WithMany(category => category.Products)
            .HasForeignKey(product => product.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Customer>()
            .HasIndex(customer => customer.Email)
            .IsUnique();

        modelBuilder.Entity<Customer>()
            .Property(customer => customer.Email)
            .HasMaxLength(150)
            .IsRequired();

        modelBuilder.Entity<Order>()
            .HasOne(order => order.Customer)
            .WithMany(customer => customer.Orders)
            .HasForeignKey(order => order.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderDetail>()
            .HasKey(orderDetail => new { orderDetail.OrderId, orderDetail.ProductId });

        modelBuilder.Entity<OrderDetail>()
            .HasOne(orderDetail => orderDetail.Order)
            .WithMany(order => order.OrderDetails)
            .HasForeignKey(orderDetail => orderDetail.OrderId);

        modelBuilder.Entity<OrderDetail>()
            .HasOne(orderDetail => orderDetail.Product)
            .WithMany(product => product.OrderDetails)
            .HasForeignKey(orderDetail => orderDetail.ProductId);
    }
}
