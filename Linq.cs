using System;
using System.Collections.Generic;
using System.Linq;

class LinqPractice
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        List<int> numbers = new List<int>();

        // Random 10 sayı üret (-100 ile 100 arasında)
        for (int i = 0; i < 10; i++)
        {
            numbers.Add(rnd.Next(-100, 101));
        }

        // Sayılar
        Console.WriteLine("Sayılar: " + string.Join(", ", numbers));

        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList(); // çift sayılar
        var oddNumbers = numbers.Where(n => n % 2 != 0).ToList(); // tek sayılar
        var positiveNumbers = numbers.Where(n => n > 0).ToList(); // pozitif sayılar
        var negativeNumbers = numbers.Where(n => n < 0).ToList(); // negatif sayılar
        var rangeNumbers = numbers.Where(n => n > 15 && n < 22).ToList(); // 15-22 arasındaki sayılar
        var squaredNumbers = numbers.Select(n => n * n).ToList(); // her sayının karesi


        var results = new Dictionary<string, IEnumerable<int>>()
            {
                { "Çift Sayılar", evenNumbers },
                { "Tek Sayılar", oddNumbers },
                { "Pozitif Sayılar", positiveNumbers },
                { "Negatif Sayılar", negativeNumbers },
                { "15'ten Büyük ve 22'den Küçük Sayılar", rangeNumbers },
                { "Sayıların Karesi", squaredNumbers }
            };
        // her bir sonuç için Console.Writeline kullanmak kodu amatör gösteriyor, bu yüzden Dictionary kullandım.

        foreach (var item in results)
        {
            Console.WriteLine($"{item.Key}: {string.Join(", ", item.Value)}");
        }

    }
}