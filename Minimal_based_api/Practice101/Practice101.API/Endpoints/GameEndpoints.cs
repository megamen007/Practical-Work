using GameApi.Api.Services;
using GameApi.Api.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace GameApi.Api.Endpoints;

public static class GameEndpoints
{
    public static void MapGameEndpoints(this IEndpointRouteBuilder routes)
    {
        var gameApi = routes.MapGroup("/api.games").WithTags("Games");

        gameApi.MapPost("/" , async (IGameService service , CreateGameDTO command) =>
        {
           var game = await service.CreateGameAsync(command);
           return TypedResults.Created($"/api/games/{game.Id}" , game);
        });


        gameApi.MapGet("/", async (IGameService service) =>
        {
           var games = await service.GetAllGamesAsync();
           return TypedResults.Ok(games);
        });

        gameApi.MapGet("/{id}" , async Task<IResult> (IGameService service , Guid id ) =>
        {
            var game = await service.GetGameByIdAsync(id);

            if (game is null)
            {
                return TypedResults.NotFound(
                    new { Message = $"|Game with ID {id} not found ."}
                );
            }
            return TypedResults.Ok(game);

        });


        gameApi.MapPut("/{id}" , async (IGameService service , Guid id , UpdateGameDTO command) =>
        {
           await service.UpdateGameAsync(id , command);
           return TypedResults.NoContent();
        });


        gameApi.MapDelete("/{id}", async (IGameService service , Guid id) =>
        {
           await service.DeleteGameAsync(id);
           return TypedResults.NoContent();
        });


    }
}