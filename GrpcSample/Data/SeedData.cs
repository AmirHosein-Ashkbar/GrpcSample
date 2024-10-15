using GrpcSample.Entities;
using GrpcSample.Context;

namespace GrpcSample.Data;

public static class SeedData
{
    public static void Seed(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.People.Any())
        {
            for (int i = 0; i < 100; i++)
            {
                context.People.Add(new Person
                {
                    Id = i,
                    FirstName = $"John{i}",
                    LastName = $"Doe{i}",
                    Age = i,
                });
            }

            context.SaveChanges();
        }
    }
}