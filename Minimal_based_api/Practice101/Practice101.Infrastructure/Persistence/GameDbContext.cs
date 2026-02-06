using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using GameApi.Api.Entities;
using Microsoft.VisualBasic;


namespace GameApi.Api.Persistence;

public class GameDbContext(DbContextOptions<GameDbContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("app");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    var sampleGame = await context.Set<Game>().FirstOrDefaultAsync(b => b.Title == "It Takes Two");
                    if (sampleGame == null)
                    {
                        sampleGame = Game.Create("It Takes Two", "Adventure", new DateTimeOffset(new DateTime(2025, 1, 3), TimeSpan.Zero), 7);
                        await context.Set<Game>().AddAsync(sampleGame);
                        await context.SaveChangesAsync();
                    }
                });
        optionsBuilder.UseSeeding((context, _) =>
                {
                    var sampleGame = context.Set<Game>().FirstOrDefault(b => b.Title == "It Takes Two");
                    if (sampleGame == null)
                    {
                        sampleGame = Game.Create("It Takes Two" , "Adventure" , new DateTimeOffset(new DateTime(2025, 1, 3), TimeSpan.Zero), 7);
                        context.Set<Game>().Add(sampleGame);
                        context.SaveChanges();
                    }
                });       
    }
}
    

