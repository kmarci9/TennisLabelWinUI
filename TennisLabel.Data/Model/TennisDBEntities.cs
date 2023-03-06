using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace TennisLabel.Data
{
    public partial class TennisDBEntities : DbContext
    {
        public TennisDBEntities()
        {
        }

        public TennisDBEntities(DbContextOptions<TennisDBEntities> options)
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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\SCAVOK\\source\\repos\\TennisLabel\\TennisLabel.Data\\TennisDB.mdf;Integrated Security=True");
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.PkCustomerId)
                    .HasName("PK__Customer__CF8CBC8CCC14B9AF");

                entity.Property(e => e.PkCustomerId).HasColumnName("pk_CustomerID");

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(300)
                    .HasColumnName("First_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(300)
                    .HasColumnName("Last_name");

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.PostalCode).HasColumnName("Postal_code");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.PkOrderId)
                    .HasName("PK__Orders__9602528B8A8AE50D");

                entity.Property(e => e.PkOrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("pk_OrderID");

                entity.Property(e => e.Comments).HasMaxLength(3000);

                entity.Property(e => e.FkCustomerId).HasColumnName("fk_CustomerID");

                entity.Property(e => e.OrderEnddate)
                    .HasColumnType("date")
                    .HasColumnName("Order_enddate");

                entity.Property(e => e.OrderStartdate)
                    .HasColumnType("date")
                    .HasColumnName("Order_startdate");

                entity.HasOne(d => d.FkCustomer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.FkCustomerId)
                    .HasConstraintName("FK__Orders__fk_Custo__25869641");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FkOrderId).HasColumnName("fk_OrderID");

                entity.Property(e => e.FkProductId).HasColumnName("fk_ProductID");

                entity.HasOne(d => d.FkOrder)
                    .WithMany()
                    .HasForeignKey(d => d.FkOrderId)
                    .HasConstraintName("FK__OrderDeta__fk_Or__2C3393D0");

                entity.HasOne(d => d.FkProduct)
                    .WithMany()
                    .HasForeignKey(d => d.FkProductId)
                    .HasConstraintName("FK__OrderDeta__fk_Pr__2D27B809");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PkProductId)
                    .HasName("PK__Products__F4A1431E69EADD86");

                entity.Property(e => e.PkProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("pk_ProductID");

                entity.Property(e => e.Brand).HasMaxLength(500);

                entity.Property(e => e.FkStringId).HasColumnName("fk_StringID");

                entity.Property(e => e.ProductName).HasMaxLength(500);

                entity.HasOne(d => d.FkString)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.FkStringId)
                    .HasConstraintName("FK__Products__fk_Str__2A4B4B5E");
            });

            modelBuilder.Entity<ProductXstring>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductXString");

                entity.Property(e => e.FkProductId).HasColumnName("fk_ProductID");

                entity.Property(e => e.FkStringId).HasColumnName("fk_StringID");

                entity.HasOne(d => d.FkProduct)
                    .WithMany()
                    .HasForeignKey(d => d.FkProductId)
                    .HasConstraintName("FK__ProductXS__fk_Pr__2F10007B");

                entity.HasOne(d => d.FkString)
                    .WithMany()
                    .HasForeignKey(d => d.FkStringId)
                    .HasConstraintName("FK__ProductXS__fk_St__300424B4");
            });

            modelBuilder.Entity<String>(entity =>
            {
                entity.HasKey(e => e.PkStringId)
                    .HasName("PK__Strings__DD222F1ECCAEC55F");

                entity.Property(e => e.PkStringId)
                    .ValueGeneratedNever()
                    .HasColumnName("pk_StringID");

                entity.Property(e => e.Brand).HasMaxLength(500);

                entity.Property(e => e.StringName).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
