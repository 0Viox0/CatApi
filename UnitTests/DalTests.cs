using Dal;
using Dal.Enums;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests;

public class DalTests
{
    private DbContextOptions<CatApiDbContext> GetInMemoryDbContextOptions()
    {
        return new DbContextOptionsBuilder<CatApiDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    }

    [Fact]
    public void AddCat_ShouldAddCat()
    {
        var options = GetInMemoryDbContextOptions();

        using (var context = new CatApiDbContext(options))
        {
            var cat = new Cat
            {
                Name = "Whiskers",
                DateOfBirth = new DateOnly(2020, 1, 1),
                Breed = "Tabby",
                Color = CatColor.Black,
                OwnerId = 1
            };

            context.Cats.Add(cat);
            context.SaveChanges();
            
            Assert.Equal(1, context.Cats.Count());
            var savedCat = context.Cats.First();
            Assert.Equal("Whiskers", savedCat.Name);
        }
    }

    [Fact]
    public void GetCatById_ShouldReturnCorrectCat()
    {
        var options = GetInMemoryDbContextOptions();

        using (var context = new CatApiDbContext(options))
        {
            var cat = new Cat
            {
                Name = "Whiskers",
                DateOfBirth = new DateOnly(2020, 1, 1),
                Breed = "Tabby",
                Color = CatColor.Tabby,
                OwnerId = 1
            };

            context.Add(cat);
            context.SaveChanges();

            var retrievedCat = context.Cats.Find(1);

            Assert.NotNull(retrievedCat);
            Assert.Equal("Whiskers", retrievedCat.Name);
        }
    }
}
