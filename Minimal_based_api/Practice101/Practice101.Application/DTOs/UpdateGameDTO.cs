namespace GameApi.Api.DTOs;
public record UpdateGameDTO(string Title, string Genre, DateTimeOffset ReleaseDate, double Rating);
