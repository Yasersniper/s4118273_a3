using AssessmentA3.Models;

namespace AssessmentA3.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        var matthew = context.Authors
            .FirstOrDefault(a => a.FullName == "Matthew Bolger");

        if (matthew == null)
        {
            matthew = new Author
            {
                FullName = "Matthew Bolger"
            };

            context.Authors.Add(matthew);
        }

        var shekhar = context.Authors
            .FirstOrDefault(a => a.FullName == "Shekhar Karla");

        if (shekhar == null)
        {
            shekhar = new Author
            {
                FullName = "Shekhar Karla"
            };

            context.Authors.Add(shekhar);
        }

        // Database generates the author IDs.
        context.SaveChanges();

        if (!context.Books.Any(b => b.BookID == "ISBN2468"))
        {
            context.Books.Add(new Book
            {
                BookID = "ISBN2468",
                AuthorID = matthew.AuthorID,
                Title = "Learning C#",
                PublishedDate = new DateOnly(2024, 3, 15),
                Price = 39.95m
            });
        }

        if (!context.Books.Any(b => b.BookID == "ISBN1357"))
        {
            context.Books.Add(new Book
            {
                BookID = "ISBN1357",
                AuthorID = shekhar.AuthorID,
                Title = "Web Development Basics",
                PublishedDate = new DateOnly(2025, 6, 10),
                Price = 49.95m
            });
        }

        if (!context.Members.Any(m => m.Email == "yaser@example.com"))
        {
            context.Members.Add(new Member
            {
                FirstName = "Yaser",
                LastName = "Shareef",
                Email = "yaser@example.com",
                MobilePhone = "0400000001"
            });
        }

        if (!context.Members.Any(m => m.Email == "alex@example.com"))
        {
            context.Members.Add(new Member
            {
                FirstName = "Alex",
                LastName = "Smith",
                Email = "alex@example.com",
                MobilePhone = "0400000002"
            });
        }

        context.SaveChanges();
    }
}