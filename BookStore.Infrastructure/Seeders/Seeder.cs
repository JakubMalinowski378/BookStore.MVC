using Bogus;
using BookStore.Domain.Entities;
using BookStore.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Infrastructure.Seeders;

public class Seeder
{
    private readonly BookStoreDbContext _dbContext;

    public Seeder(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Seed()
    {
        if(await _dbContext.Database.CanConnectAsync())
        {
            if (!_dbContext.Users.Any())
                await SeedUsers();
            if (!_dbContext.Genres.Any())
                await SeedGenres();
            if (!_dbContext.Languages.Any())
                await SeedLanguages();
            if (!_dbContext.Authors.Any())
                await SeedAuthors();
            await _dbContext.SaveChangesAsync();
            if (!_dbContext.Books.Any())
                await SeedBooks();
            await _dbContext.SaveChangesAsync();
        }
    }

    private async Task SeedUsers()
    {
        var hasher = new PasswordHasher<IdentityUser>();
        var users = new IdentityUser[]
        {
            new IdentityUser()
            {
                UserName = "johndoe",
                NormalizedUserName = "JOHNDOE",
                Email = "test@gmail.com",
                NormalizedEmail = "TEST@GMAIL.COM",
                EmailConfirmed = true,
            },
            new IdentityUser()
            {
                UserName = "janedoe",
                NormalizedUserName = "JANEDOE",
                Email = "jane.doe@example.com",
                NormalizedEmail = "JANE.DOE@EXAMPLE.COM",
                EmailConfirmed = true,
            }
        };
        users[0].PasswordHash = hasher.HashPassword(users[0], "lAHO{I%&*)S4DVN_$f@");
        users[1].PasswordHash = hasher.HashPassword(users[1], "lAHO{I%&*)S4DVN_$f@");
        await _dbContext.Users.AddRangeAsync(users);
    }

    private async Task SeedBooks()
    {
        var genres = _dbContext.Genres.ToList();
        var languages = _dbContext.Languages.ToList();
        var authors = _dbContext.Authors.ToList();
        var users = _dbContext.Users.ToList();
        var rnd = new Random();
        var faker = new Faker();
        var books = new Book[100];
        for(int i = 0; i < 100; i++)
        {
            int genreCount = rnd.Next(1, 4);
            var bookGenres = new List<Genre>();
            while(bookGenres.Count < genreCount)
            {
                var index = rnd.Next(genres.Count - 1);
                if(!bookGenres.Contains(genres[index]))
                    bookGenres.Add(genres[index]);
            }
            var user = users[rnd.Next(users.Count - 1)];
            books[i] = new Book()
            {
                Genres = bookGenres,
                Language = languages[rnd.Next(languages.Count - 1)],
                Author = authors[rnd.Next(authors.Count - 1)],
                User = user,
                UserId = user.Id,
                Title = String.Join(' ', faker.Random.WordsArray(4)),
                Description = faker.Commerce.ProductDescription(),
                PageNumbers = rnd.Next(10, 5000),
                Price = faker.Random.Decimal(10, 90)
            };
        }
        await _dbContext.Books.AddRangeAsync(books);
    }

    private async Task SeedAuthors()
    {
        var authors = new Author[]
        {
            new Author(){ FirstName="Franz", LastName="Kafka" },
            new Author(){ FirstName="William", LastName="Shakespeare" },
            new Author(){ FirstName="Fiodor", LastName="Dostojewski" },
            new Author(){ FirstName="George", LastName="Orwell" },
            new Author(){ FirstName="Mark", LastName="Twain" },
            new Author(){ FirstName="Joseph", LastName="Conrad" },
            new Author(){ FirstName="Adam", LastName="Mickiewicz" }
        };
        await _dbContext.Authors.AddRangeAsync(authors);
    }

    private async Task SeedLanguages()
    {
        var languages = new Language[]
        {
            new Language(){ Value="Polish" },
            new Language(){ Value="English" },
            new Language(){ Value="Deutsch" },
            new Language(){ Value="French" },
            new Language(){ Value="Spanish" },
        };
        await _dbContext.Languages.AddRangeAsync(languages);
    }

    private async Task SeedGenres()
    {
        var genres = new Genre[]
        {
            new Genre(){ Value="Action" },
            new Genre(){ Value="Adventure" },
            new Genre(){ Value="Classic" },
            new Genre(){ Value="Comic" },
            new Genre(){ Value="Detective" },
            new Genre(){ Value="Fantasy" },
            new Genre(){ Value="Horror" },
            new Genre(){ Value="LiteraryFiction" },
            new Genre(){ Value="Romance" },
            new Genre(){ Value="ScienceFiction" },
            new Genre(){ Value="ShortStory" },
            new Genre(){ Value="Thriller" },
            new Genre(){ Value="Biography" },
            new Genre(){ Value="Cookbook" }
        };
        await _dbContext.Genres.AddRangeAsync(genres);
    }
}
