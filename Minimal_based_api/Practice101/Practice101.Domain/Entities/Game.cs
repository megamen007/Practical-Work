using System.Data;
using System.Runtime.CompilerServices;

namespace GameApi.Api.Entities;
public sealed class Game : EntityBase
{
    public string Title {get; private set;}
    public string Genre {get; private set;}
    public DateTimeOffset ReleaseDate {get ; private set;}
    public double Rating { get; private set;}

    private Game()
    {
        Title = string.Empty;
        Genre = string.Empty;
    }

    private Game(string title, string genre, DateTimeOffset releaseDate, double rating)
    {
        Title = title;
        Genre = genre;
        ReleaseDate = releaseDate;
        Rating = rating;
    }

    public static Game Create(string title, string genre, DateTimeOffset releaseDate, double rating)
    {
        ValidateInputs(title, genre, releaseDate, rating);
        return new Game(title, genre, releaseDate, rating);
        
    }


    public void Update(string title, string genre, DateTimeOffset releaseDate, double rating)
    {
        ValidateInputs(title, genre, releaseDate, rating);

        Title = title;
        Genre = genre;
        ReleaseDate = releaseDate;
        Rating = rating;

        UpdateLastModified();
    }

    private static void ValidateInputs(string title, string genre , DateTimeOffset releaseDate, double rating)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Game Title cannot be Null or Empty.", nameof(title));

        if (string.IsNullOrWhiteSpace(genre))
            throw new ArgumentException("Game genre cannot be Null or Empty ",nameof(genre));

        if (releaseDate > DateTimeOffset.UtcNow)
            throw new ArgumentException("Game Release Date cannot be in the future", nameof(releaseDate));

        if (rating < 0 || rating > 10)
            throw new ArgumentException("Game Rating must be between  0 and 10" , nameof(rating));
            
    }

}