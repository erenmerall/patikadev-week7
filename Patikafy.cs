using System;
using System.Collections.Generic;
using System.Linq;

class Artist
{
    public string Name { get; set; }
    public string Genre { get; set; }
    public int DebutYear { get; set; }
    public int AlbumSales { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Genre} - {DebutYear} - {AlbumSales} milyon";
    }
}
class Patikafy
{
    static void Main(string[] args)
    {
        List<Artist> artists = new List<Artist>
        {
            new Artist { Name = "Ajda Pekkan", Genre = "Pop", DebutYear = 1968, AlbumSales = 20 },
            new Artist { Name = "Sezen Aksu", Genre = "Türk Halk Müziği/Pop", DebutYear = 1971, AlbumSales = 10 },
            new Artist { Name = "Funda Arar", Genre = "Pop", DebutYear = 1999, AlbumSales = 3 },
            new Artist { Name = "Sertab Erener", Genre = "Pop", DebutYear = 1994, AlbumSales = 5 },
            new Artist { Name = "Sıla", Genre = "Pop", DebutYear = 2009, AlbumSales = 3 },
            new Artist { Name = "Serdar Ortaç", Genre = "Pop", DebutYear = 1994, AlbumSales = 10 },
            new Artist { Name = "Tarkan", Genre = "Pop", DebutYear = 1992, AlbumSales = 40 },
            new Artist { Name = "Hande Yener", Genre = "Pop", DebutYear = 1999, AlbumSales = 7 },
            new Artist { Name = "Hadise", Genre = "Pop", DebutYear = 2005, AlbumSales = 5 },
            new Artist { Name = "Gülben Ergen", Genre = "Pop/Türk Halk Müziği", DebutYear = 1997, AlbumSales = 10 },
            new Artist { Name = "Neşet Ertaş", Genre = "Türk Halk Müziği/Türk Sanat Müziği", DebutYear = 1960, AlbumSales = 2 }
        };

        // adı s ile başlayan sanatçılar
        var artistsStartingWithS = artists
            .Where(a => a.Name.StartsWith("S", StringComparison.OrdinalIgnoreCase))
            .Select(a => a.Name);

        // 10 milyondan fazla albüm satan sanatçılar
        var artistsWithHighSales = artists
            .Where(a => a.AlbumSales > 10)
            .Select(a => a.Name);

        // 2000 yılı öncesi çıkış yapmış ve pop müzik yapanlar (yılı ve ada göre sıralı)
        var oldPopArtists = artists
            .Where(a => a.DebutYear < 2000 && a.Genre.ToLower().Contains("pop"))
            .OrderBy(a => a.DebutYear)
            .ThenBy(a => a.Name);

        // en çok albüm satan sanatçı
        var topSellingArtist = artists.OrderByDescending(a => a.AlbumSales).First();

        // en yeni ve en eski çıkış yapan sanatçılar
        var newestArtist = artists.OrderByDescending(a => a.DebutYear).First();
        var oldestArtist = artists.OrderBy(a => a.DebutYear).First();

        // Sonuçları yazdırma
        var results = new Dictionary<string, IEnumerable<object>>
        {
            { "İsmi 'S' ile başlayan sanatçılar", artistsStartingWithS.Cast<object>() },
            { "10 milyondan fazla albüm satan sanatçılar", artistsWithHighSales.Cast<object>() },
            { "2000 yılı öncesi çıkış yapmış ve pop Müzik yapanlar", oldPopArtists.Cast<object>() },
            { "En çok albüm satan sanatçı", new List<object> { topSellingArtist } },
            { "En yeni çıkış yapan sanatçı", new List<object> { newestArtist } },
            { "En eski çıkış yapan sanatçı", new List<object> { oldestArtist } }
        };

        foreach (var item in results)
        {
            Console.WriteLine($"\n{item.Key}:");
            foreach (var obj in item.Value)
            {
                if (obj is Artist artist)
                    Console.WriteLine(artist);
                else
                    Console.WriteLine(obj);
            }
        }

    }
}