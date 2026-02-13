using Devops.Infrastructure.Presestence;
using Microsoft.EntityFrameworkCore;

namespace Devops.API;

public static class MigrationRunner
{
    public static async Task RunMigrationAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        var pending = await context.Database.GetPendingMigrationsAsync();

        if (!pending.Any())
        {
            Console.WriteLine("[Migration] no pending migrations");
            return;
        }
        Console.WriteLine($"[Migration] Applying {pending.Count()} migration(s):");
        foreach (var m in pending)
            Console.WriteLine($"  → {m}");
        
        await context.Database.MigrateAsync();
        Console.WriteLine("[Migration] Done.");
    }
}