﻿using Microsoft.EntityFrameworkCore;
namespace Northwind.EntityModels;
public class NorthwindDb:DbContext {
    // These two properties map to tables in the database.
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        string databaseFile = "Northwind.db";
        string path = Path.Combine(Environment.CurrentDirectory, databaseFile);
        string connectionString = $"Data Source={path}";
        WriteLine($"Connection: {connectionString}");
        optionsBuilder.UseSqlite(connectionString);
        optionsBuilder.LogTo(WriteLine) // This is the Console method.
#if DEBUG
  .EnableSensitiveDataLogging() // Include SQL parameters.
  .EnableDetailedErrors()
#endif
            ;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // Example of using Fluent API instead of attributes
        // to limit the length of a category name to 15.
        modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired() // NOT NULL
            .HasMaxLength(15);
        // Some SQLite-specific configuration.
        if (Database.ProviderName?.Contains("Sqlite") ?? false) {
            // To "fix" the lack of decimal support in SQLite.
            modelBuilder.Entity<Product>()
                .Property(product => product.Cost)
                .HasConversion<double>();
        }
    }
    
}