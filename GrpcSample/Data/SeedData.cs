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
            for (int i = 1; i <= 100; i++)
            {
                context.People.Add(new Person
                {
                    FirstName = $"John{i}",
                    LastName = $"Doe{i}",
                    Age = i,
                });
            }

            context.SaveChanges();
        }
    }
}