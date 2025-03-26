using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts;

public class ServiceProviderContext(DbContextOptions<ServiceProviderContext> options) : DbContext(options)
{
    public DbSet<ServiceProvider> ServiceProviders { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var customDateTime = new DateTime(2025, 3, 27, 19, 32, 0, 0, DateTimeKind.Local);

        //seeding data
        modelBuilder.Entity<ServiceProvider>()
          .HasData([
              new(){
                    Id = "c710f447-9288-4d60-a7ad-7ee3b11a8219",
                    UpdatedAt = customDateTime,
                    CreatedAt = customDateTime,
                    Name = "Service Provider 1",
                    ContactDetails = "Contact Details 1",
                },
                new(){
                    Id = "7ed42c39-2f22-4229-b7a2-5c3ca53fa164",
                    UpdatedAt = customDateTime,
                    CreatedAt = customDateTime,
                    Name = "Service Provider 2",
                    ContactDetails = "Contact Details 2",
                },
                new(){
                    Id = "2364468a-f4da-415f-b170-1e51f3c3bbfc",
                    UpdatedAt = customDateTime,
                    CreatedAt = customDateTime,
                    Name = "Service Provider 3",
                    ContactDetails = "Contact Details 3",
                }
              ]);
        modelBuilder.Entity<Product>()
            .HasData([
                new(){
                    CreatedAt = customDateTime,
                    Id = "6b2e8e31-4ec3-4e38-b2f9-4e1a7618bc06",
                    Name = "Product 1",
                    Price = 100.0,
                    ServiceProviderId = "c710f447-9288-4d60-a7ad-7ee3b11a8219",
                    UpdatedAt = customDateTime
                },
                new(){
                    CreatedAt = customDateTime,
                    Id = "fb442d4b-1a9d-431e-af2d-245913adca77",
                    Name = "Product 2",
                    Price = 150.0,
                    ServiceProviderId = "c710f447-9288-4d60-a7ad-7ee3b11a8219",
                    UpdatedAt = customDateTime
                },
                new(){
                    CreatedAt = customDateTime,
                    Id = "49a5ac1b-729f-45df-b7b4-df159cb2aed1",
                    Name = "Product 3",
                    Price = 170.0,
                    ServiceProviderId = "c710f447-9288-4d60-a7ad-7ee3b11a8219",
                    UpdatedAt = customDateTime
                },
                new(){
                    CreatedAt = customDateTime,
                    Id = "fd67dbc7-3b02-4712-a458-ed7c871ada79",
                    Name = "Product 4",
                    Price = 100.0,
                    ServiceProviderId = "7ed42c39-2f22-4229-b7a2-5c3ca53fa164",
                    UpdatedAt = customDateTime
                },
                new(){
                    CreatedAt = customDateTime,
                    Id = "d20cb994-1b19-44a2-8480-914e7d914e52",
                    Name = "Product 5",
                    Price = 100.0,
                    ServiceProviderId = "7ed42c39-2f22-4229-b7a2-5c3ca53fa164",
                    UpdatedAt = customDateTime
                },
                new(){
                    CreatedAt = customDateTime,
                    Id = "e4f394cc-4986-4548-9d88-2bc7c5c5ba8d",
                    Name = "Product 6",
                    Price = 100.0,
                    ServiceProviderId = "7ed42c39-2f22-4229-b7a2-5c3ca53fa164",
                    UpdatedAt = customDateTime
                },
                new(){
                    CreatedAt = customDateTime,
                    Id = "4f2ed00c-34ed-4401-b204-2dc175725ade",
                    Name = "Product 7",
                    Price = 100.0,
                    ServiceProviderId ="2364468a-f4da-415f-b170-1e51f3c3bbfc",
                    UpdatedAt = customDateTime
                },
                new(){
                    CreatedAt = customDateTime,
                    Id = "f408f0f2-8c31-4a2a-a309-1c44aaf6ab71",
                    Name = "Product 8",
                    Price = 100.0,
                    ServiceProviderId = "2364468a-f4da-415f-b170-1e51f3c3bbfc",
                    UpdatedAt = customDateTime
                },
                new(){
                    CreatedAt = customDateTime,
                    Id = "7bf5fb24-786d-46b1-8dd1-316ccab56a24",
                    Name = "Product 9",
                    Price = 100.0,
                    ServiceProviderId ="2364468a-f4da-415f-b170-1e51f3c3bbfc",
                    UpdatedAt = customDateTime
                },
                ]);
    }
}
