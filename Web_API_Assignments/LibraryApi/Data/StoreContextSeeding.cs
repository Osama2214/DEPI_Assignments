using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LibraryApi.Data;

public static class StoreContextSeeding
{
    public static async Task SeedAsync(
        LibraryDbContext context, string contentRootPath)
    {
        if (await context.Authors.AnyAsync())
        {
            return;
        }

        var filePath = Path.Combine(
            contentRootPath, "Data", "Seeding", "Authors.json");

        var authorsData = await File.ReadAllTextAsync(filePath);
        var authors = JsonSerializer.Deserialize<List<Author>>(authorsData);

        if (authors == null)
        {
            return;
        }

        await context.Authors.AddRangeAsync(authors);
        await context.SaveChangesAsync();
    }
}
