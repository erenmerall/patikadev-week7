using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

class Authors
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
}

class Books
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
}

class Linq_Join
{
    static void Main(string[] args)
    {
        // yazarlar listesi 
        List<Authors> authors = new List<Authors>
        {
            new Authors { AuthorId = 1, Name = "Orhan Pamuk" },
            new Authors { AuthorId = 2, Name = "Elif Şafak" },
            new Authors { AuthorId = 3, Name = "Ahmet Ümit" }
        };

        // kitaplar listesi
        List<Books> books = new List<Books>
        {
            new Books { BookId = 1, Title = "Kar", AuthorId = 1 },
            new Books { BookId = 2, Title = "İstanbul", AuthorId = 1 },
            new Books { BookId = 3, Title = "10 minutes 38 seconds in this strange world", AuthorId = 2 },
            new Books { BookId = 4, Title = "Beyoğlu Rapsodisi", AuthorId = 3 }
        };

        // linq sorgusu
        var bookWithAuthors = from book in books
                            join author in authors
                            on book.AuthorId equals author.AuthorId
                            select new
                            {
                                BookTitle = book.Title,
                                AuthorName = author.Name
                            };

        // sonuçları yazdırma
        foreach (var item in bookWithAuthors)
        {
            Console.WriteLine($"Kitap: {item.BookTitle}, Yazar: {item.AuthorName}");
        }
    }
}