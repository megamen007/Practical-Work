
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using GameApi.Api.DTOs;
using GameApi.Api.Entities;
using GameApi.Api.Services;
using GameApi.Api.Persistence;

namespace GameApi.Api.Services;
public class GameService : IGameService
{
    private readonly GameDbContext _dbContext;
    private readonly ILogger<GameService> _logger;

    public  GameService(GameDbContext dbContext, ILogger<GameService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    // Create 
    public async Task<GameDTO> CreateGameAsync(CreateGameDTO command)
    {
        var game = Game.Create(command.Title, command.Genre, command.ReleaseDate , command.Rating);

        await _dbContext.Games.AddAsync(game);
        await _dbContext.SaveChangesAsync();


        return new GameDTO(
            game.Id,
            game.Title,
            game.Genre,
            game.ReleaseDate,
            game.Rating
        );
    }

    // Read
    public async Task<IEnumerable<GameDTO>> GetAllGamesAsync()
    {
        return await _dbContext.Games
            .AsNoTracking()
            .Select(game => new GameDTO(
                game.Id,
                game.Title,
                game.Genre,
                game.ReleaseDate,
                game.Rating
            ))
            .ToListAsync();
    }

    //  Get a game details  
    public async Task<GameDTO?> GetGameByIdAsync(Guid id)
    {
        var game = await _dbContext.Games
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.Id == id );

        if (game == null)
            return null;

        return new GameDTO(
            game.Id,
            game.Title,
            game.Genre,
            game.ReleaseDate,
            game.Rating
        );
    }

    // Update a game details 
    public async Task UpdateGameAsync(Guid id, UpdateGameDTO command)
    {
        var gameToUpdate = await _dbContext.Games.FindAsync(id);
        if( gameToUpdate is null)
            throw new ArgumentNullException($"Invalid Game Id.");
        gameToUpdate.Update(command.Title , command.Genre, command.ReleaseDate, command.Rating);
        await _dbContext.SaveChangesAsync();
    }


    // Delete
    public async Task DeleteGameAsync(Guid id)
    {
        var gameToDelete = await _dbContext.Games.FindAsync(id);
        if (gameToDelete != null)
        {
            _dbContext.Games.Remove(gameToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }

}