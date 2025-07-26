using System;
using System.Collections.Generic;
using System.Linq;

class Series
{
    public string Name { get; set; }
    public int YearOfConstruction { get; set; }
    public string Genre { get; set; }
    public int YearOfPublication { get; set; }
    public string Directors { get; set; }
    public string FirstPlatform { get; set; }


    public override string ToString()
    {
        return $"{Name} - {YearOfConstruction} - {Genre} - {YearOfPublication} - {Directors} - {FirstPlatform}";
    }
}

class ComedySeries
{
    public string Name { get; set; }
    public string Genre { get; set; }
    public string Directors { get; set; }


    public override string ToString()
    {
        return $"{Name} - {Genre} - {Directors}";
    }
}

class Patikaflix
{
    static void Main(string[] args)
    {
        List<Series> series = new List<Series>
        {
            new Series { Name = "Avrupa Yakası", YearOfConstruction = 2004, Genre = "Komedi", YearOfPublication = 2004, Directors = "Yüksel Aksu", FirstPlatform = "Kanal D" },
            new Series { Name = "Yalan Dünya", YearOfConstruction = 2012, Genre = "Komedi", YearOfPublication = 2012, Directors = "Gülseren Buda Başkaya", FirstPlatform = "Fox TV" },
            new Series { Name = "Jet Sosyete", YearOfConstruction = 2018, Genre = "Komedi", YearOfPublication = 2018, Directors = "Gülseren Buda Başkaya", FirstPlatform = "TV8" },
            new Series { Name = "Dadı", YearOfConstruction = 2006, Genre = "Komedi", YearOfPublication = 2006, Directors = "Yusuf Pirhasan", FirstPlatform = "Kanal D" },
            new Series { Name = "Belalı Baldız", YearOfConstruction = 2007, Genre = "Komedi", YearOfPublication = 2007, Directors = "Yüksel Aksu", FirstPlatform = "Kanal D" },
            new Series { Name = "Arka Sokaklar", YearOfConstruction = 2004, Genre = "Polisiye/Dram", YearOfPublication = 2004, Directors = "Orhan Oğuz", FirstPlatform = "Kanal D" },
            new Series { Name = "Aşkı Memnu", YearOfConstruction = 2008, Genre = "Dram/Romantik", YearOfPublication = 2008, Directors = "Hilal Saral", FirstPlatform = "Kanal D" },
            new Series { Name = "Muhteşem Yüzyıl", YearOfConstruction = 2011, Genre = "Tarihi/Dram", YearOfPublication = 2011, Directors = "Mercan Çilingiroğlu", FirstPlatform = "Star TV" },
            new Series { Name = "Yaprak Dökümü", YearOfConstruction = 2006, Genre = "Dram", YearOfPublication = 2006, Directors = "Serdar Akar", FirstPlatform = "Kanal D" },
        };

        // komedi dizileri
        var comedySeries = series
            .Where(s => s.Genre.ToLower().Contains("komedi"))
            .Select(s => new ComedySeries
            {
                Name = s.Name,
                Genre = s.Genre,
                Directors = s.Directors
            })
            .OrderBy(c => c.Name)
            .ThenBy(c => c.Directors)
            .ToList();

        Console.WriteLine("Komedi Dizileri");
        foreach (var comedy in comedySeries)
        {
            Console.WriteLine(comedy);
        }
    }
}