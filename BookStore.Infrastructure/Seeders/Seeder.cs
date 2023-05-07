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
        var books = new Books[100];
        for(int i = 0; i < 100; i++)
        {
            int genreCount = rnd.Next(1, 4);
            var bookGenres = new List<Genres>();
            while(bookGenres.Count < genreCount)
            {
                var index = rnd.Next(genres.Count - 1);
                if(!bookGenres.Contains(genres[index]))
                    bookGenres.Add(genres[index]);
            }
            var user = users[rnd.Next(users.Count - 1)];
            books[i] = new Books()
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
        var authors = new Authors[]
        {
            new Authors(){ FirstName="Franz", LastName="Kafka" },
            new Authors(){ FirstName="William", LastName="Shakespeare" },
            new Authors(){ FirstName="Fiodor", LastName="Dostojewski" },
            new Authors(){ FirstName="George", LastName="Orwell" },
            new Authors(){ FirstName="Mark", LastName="Twain" },
            new Authors(){ FirstName="Joseph", LastName="Conrad" },
            new Authors(){ FirstName="Adam", LastName="Mickiewicz" }
        };
        await _dbContext.Authors.AddRangeAsync(authors);
    }

    private async Task SeedLanguages()
    {
        var languages = new Languages[]
        {
            new Languages(){ Language="Polish" },
            new Languages(){ Language="English" },
            new Languages(){ Language="Deutsch" },
            new Languages(){ Language="French" },
            new Languages(){ Language="Spanish" },
        };
        await _dbContext.Languages.AddRangeAsync(languages);
    }

    private async Task SeedGenres()
    {
        var genres = new Genres[]
        {
            new Genres(){ Genre="Action" },
            new Genres(){ Genre="Adventure" },
            new Genres(){ Genre="Classic" },
            new Genres(){ Genre="Comic" },
            new Genres(){ Genre="Detective" },
            new Genres(){ Genre="Fantasy" },
            new Genres(){ Genre="Horror" },
            new Genres(){ Genre="LiteraryFiction" },
            new Genres(){ Genre="Romance" },
            new Genres(){ Genre="ScienceFiction" },
            new Genres(){ Genre="ShortStory" },
            new Genres(){ Genre="Thriller" },
            new Genres(){ Genre="Biography" },
            new Genres(){ Genre="Cookbook" }
        };
        await _dbContext.Genres.AddRangeAsync(genres);
    }
}
