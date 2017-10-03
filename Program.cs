using System;
using System.Collections.Generic;

namespace Readable_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<Item>()
            {
                new Item() { Title = "fantome", ItemType = ItemTypes.Album},
                new Item() { Title = "finally", ItemType = ItemTypes.Album},
                new Item() { Title = "ダンケルク", ItemType = ItemTypes.DVD}
            };

            var calculator = new FeeCalculator();
            var totalFee = calculator.Calculate("12345678", items);
            Console.WriteLine($"合計金額は{totalFee:C}円です");
            Console.ReadLine();
        }
    }
}
