
using GameApi.Api.DTOs;
namespace GameApi.Api.Services;
public interface IGameService
{
        Task<GameDTO> CreateGameAsync(CreateGameDTO command);
        Task<GameDTO?> GetGameByIdAsync(Guid id);
 
        Task<IEnumerable<GameDTO>> GetAllGamesAsync();

        Task UpdateGameAsync(Guid id, UpdateGameDTO command);
        Task DeleteGameAsync(Guid id);
}