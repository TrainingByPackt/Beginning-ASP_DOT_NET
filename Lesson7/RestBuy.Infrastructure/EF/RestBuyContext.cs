using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBuy.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBuy.Infrastructure.EF
{
    public class RestBuyContext : DbContext
    {
        const string hiloName = "order_hilo";

        const string productTable = "Product";
        const string orderTable = "Order";
        const string orderItemTable = "OrderItem";
        const string stockAmount = "StockAmount";

        public RestBuyContext(DbContextOptions<RestBuyContext> options) : base(options)
        {

        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Order> Order => Set<Order>();
        public DbSet<StockAmount> StockAmounts
            => Set<StockAmount>();



        // configure each of our entities.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseSequenceHiLo(hiloName);
            var sequence = modelBuilder.HasSequence(hiloName);
            sequence.IncrementsBy(100);
            sequence.StartsAt(1000);

            modelBuilder.Entity<Product>(ConfigureProduct);
            modelBuilder.Entity<OrderItem>(ConfigureOrderItem);
            modelBuilder.Entity<Order>(ConfigureOrder);
            modelBuilder.Entity<StockAmount>
               (ConfigureStockAmount);


        }

        // Product entity configuration
        void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(productTable);

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ci => ci.Price)
                .IsRequired();

            builder.Property(ci => ci.PictureUri)
                .IsRequired();

            builder.Property(ci => ci.Category)
                .IsRequired();

        }

        /// Order entity configuration
        void ConfigureOrder(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(orderTable);

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.CreateDate)
                .IsRequired();
            builder.Property(cb => cb.IsConfirmed).IsRequired();
            builder.Property(cb => cb.UserId).IsRequired();
            builder.HasMany(cb => cb.OrderItems).WithOne().IsRequired();
        }


        void ConfigureStockAmount(EntityTypeBuilder<StockAmount> builder)
        {
            builder.ToTable(stockAmount);

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.ProductId)
                .IsRequired();

            builder.Property(ci => ci.Quantity)

                .IsRequired().IsConcurrencyToken();
        }

        /// Order Item entity configuration
        void ConfigureOrderItem(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable(orderItemTable);

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.Price)
                .IsRequired();

            builder.Property(c => c.ProductId)
                .IsRequired();
            builder.Property(c => c.Quantity)
                .IsRequired();
        }
    }
}
