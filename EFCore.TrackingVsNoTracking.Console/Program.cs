using EFCore.TrackingVsNoTracking.Console.Context;
using EFCore.TrackingVsNoTracking.Console.Entities;
using Microsoft.EntityFrameworkCore;

InitializeDatabase();
// UpdateFirstPlayersTracking();
// UpdateFirstPlayersAsNoTracking();
// UpdateFirstPlayersAsNoTrackingWithIdentityResolution();

static void UpdateFirstPlayersTracking()
{
    using var context = new DemoContext();
    var players = context.Players.ToList();
    players[0].Name = "Updated Player";
    context.SaveChanges();
}

static void UpdateFirstPlayersAsNoTracking()
{
    using var context = new DemoContext();
    var players = context.Players.AsNoTracking().ToList();
    players[0].Name = "Updated Player";
    context.SaveChanges();

}

static void UpdateFirstPlayersAsNoTrackingWithIdentityResolution()
{
    using var context = new DemoContext();
    var players = context.Players.AsNoTrackingWithIdentityResolution().ToList();
    players[0].Name = "Updated Player";
    context.SaveChanges();
}

static void InitializeDatabase()
{
    using var context = new DemoContext();
    ResetDataBase(context);
    AddTeamAndPlayers(context, "São Paulo Futebol Club");
    AddTeamAndPlayers(context, "Sport Club Corinthians Paulista");
    context.SaveChanges();
}

static void ResetDataBase(DemoContext context)
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

static void AddTeamAndPlayers(DemoContext context, string team)
{
    context.Teams.Add(new Team
    {
        Name = team,
        Players = Enumerable.Range(1, 50).Select(p => new Player
        {

            Name = $"{p}º - Player",
        }).ToList()
    });
}
