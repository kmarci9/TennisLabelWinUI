using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TennisLabel.Data;   

public partial class TennisDbContext : DbContext
{
    public TennisDbContext()
    {
    }

    public TennisDbContext(DbContextOptions<TennisDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductXstring> ProductXstrings { get; set; }

    public virtual DbSet<String> Strings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=C:\\Users\\SCAVOK\\source\\repos\\TennisLabel\\TennisLabel.Data\\TennisDB.db;");
        optionsBuilder.EnableSensitiveDataLogging();
    } 


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.PkCustomerId);

            entity.Property(e => e.PkCustomerId).HasColumnName("pk_CustomerID");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("Last_name");
            entity.Property(e => e.PostalCode).HasColumnName("Postal_code");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.PkOrderId);

            entity.Property(e => e.PkOrderId).HasColumnName("pk_OrderID");
            entity.Property(e => e.DtOrderEnddate).HasColumnName("dt_Order_enddate");
            entity.Property(e => e.DtOrderStartdate).HasColumnName("dt_Order_startdate");
            entity.Property(e => e.FkCustomerId).HasColumnName("fk_CustomerID");

            entity.HasOne(d => d.FkCustomer).WithMany(p => p.Orders).HasForeignKey(d => d.FkCustomerId);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FkOrderId).HasColumnName("fk_OrderID");
            entity.Property(e => e.FkProductId).HasColumnName("fk_ProductID");

            entity.HasOne(d => d.FkOrder).WithMany().HasForeignKey(d => d.FkOrderId);

            entity.HasOne(d => d.FkProduct).WithMany().HasForeignKey(d => d.FkProductId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PkProductId);

            entity.Property(e => e.PkProductId).HasColumnName("pk_ProductID");
            entity.Property(e => e.FkStringId).HasColumnName("fk_StringID");

            entity.HasOne(d => d.FkString).WithMany(p => p.Products).HasForeignKey(d => d.FkStringId);
        });

        modelBuilder.Entity<ProductXstring>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProductXString");

            entity.Property(e => e.FkProductId).HasColumnName("fk_ProductID");
            entity.Property(e => e.FkStringId).HasColumnName("fk_StringID");

            entity.HasOne(d => d.FkProduct).WithMany().HasForeignKey(d => d.FkProductId);

            entity.HasOne(d => d.FkString).WithMany().HasForeignKey(d => d.FkStringId);
        });

        modelBuilder.Entity<String>(entity =>
        {
            entity.HasKey(e => e.PkStringId);

            entity.Property(e => e.PkStringId).HasColumnName("pk_StringID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
