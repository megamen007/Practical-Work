namespace GameApi.Api.DTOs;
public record CreateGameDTO(string Title, string Genre, DateTimeOffset ReleaseDate, double Rating);
