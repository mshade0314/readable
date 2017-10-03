using System;
using System.Collections.Generic;
using System.Linq;

namespace Readable_Before
{
    public class FeeCalculator
    {
        public FeeCalculator() { }

        public decimal Calculate(string id, IEnumerable<Item> list)
        {
            if (list == null) throw new ArgumentException(nameof(list));
            if (!list.Any()) return 0;

            decimal sum = 0;
            var cnt = 0;
            foreach (var x in list)
            {
                if (x.MuryoFlg != 1)
                {
                    var yen = 0m;
                    switch (x.ItemType)
                    {
                        case ItemTypes.SingleCD:
                            yen = 100; break;
                        case ItemTypes.Album:
                            yen = 300; cnt++; break;
                        case ItemTypes.DVD:
                            yen = 400; break;
                        case ItemTypes.Bluelay:
                            yen = 500; break;
                    }
                    sum += yen;
                }
                else
                {
                    continue;
                }
            }

            // cntが5以上なら値引きする
            if (cnt >= 5)
            {
                sum -= 500 * (cnt / 5);
            }

            if (string.IsNullOrEmpty(id)) throw new ArgumentException(nameof(id));
            var obj = getdata(id);
            if (obj.Type == MemberTypes.Premium)
            {
                // 合計金額に0.9をかける
                sum *= 0.9m;
            }

            return Math.Floor(sum * 1.08m);
        }

        private Mem getdata(string id)
        {
            if (id == "12345678")
            {
                return new Mem() { Name = "Tarou", Type = MemberTypes.Standard };
            }
            return null;
        }
    }

    public class Mem
    {
        public string Name { get; set; }
        public MemberTypes Type { get; set; }
    }

    public enum MemberTypes
    {
        Standard,
        Premium
    }

    public class Item
    {
        public string Title { get; set; }
        public int MuryoFlg { get; set; }
        public ItemTypes ItemType { get; set; }
    }

    public enum ItemTypes
    {
        SingleCD,
        Album,
        DVD,
        Bluelay
    }
}
