using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Szalloda
{
    internal class Booking
    {
        public int Id { get; set; }
        public int Room { get; set; }
        public int Arrival { get; set; }
        public int Departure { get; set; }
        public int Guests { get; set; }
        public int Breakfast { get; set; }
        public string NameId { get; set; } = "";

        public int Nights => Departure - Arrival;
    }

    internal class Program
    {
        static int RoomPriceByArrivalDay(int arrivalDay)
        {
            if (arrivalDay >= 1 && arrivalDay <= 120) return 9000;
            if (arrivalDay >= 121 && arrivalDay <= 243) return 10000;
            return 8000;
        }

        static int ExtraBedFeePerNight(int guests) => guests == 3 ? 2000 : 0;
        static int BreakfastFeePerPersonPerNight => 1100;

        static int CalcBookingCost(Booking b)
        {
            int nights = b.Nights;
            int room = RoomPriceByArrivalDay(b.Arrival) * nights;
            int extra = ExtraBedFeePerNight(b.Guests) * nights;
            int breakfast = (b.Breakfast == 1 ? b.Guests * BreakfastFeePerPersonPerNight * nights : 0);
            return room + extra + breakfast;
        }

        static (string[] monthNames, int[] monthLengths, int[] monthStarts) ReadMonthsOrFallback(string path)
        {
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path)
                                .Select(l => l.Trim())
                                .Where(l => l.Length > 0)
                                .ToList();

                var names = new List<string>();
                var lens = new List<int>();
                var starts = new List<int>();

                for (int i = 0; i + 2 < lines.Count && names.Count < 12; i += 3)
                {
                    names.Add(lines[i]);
                    lens.Add(int.Parse(lines[i + 1], CultureInfo.InvariantCulture));
                    starts.Add(int.Parse(lines[i + 2], CultureInfo.InvariantCulture));
                }

                if (names.Count == 12 && lens.Count == 12 && starts.Count == 12)
                    return (names.ToArray(), lens.ToArray(), starts.ToArray());
            }

            string[] fallbackNames = new[]
            {
                "január","február","március","április","május","június",
                "július","augusztus","szeptember","október","november","december"
            };
            int[] fallbackLens = new[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int[] fallbackStarts = new int[12];
            fallbackStarts[0] = 1;
            for (int i = 1; i < 12; i++)
                fallbackStarts[i] = fallbackStarts[i - 1] + fallbackLens[i - 1];

            return (fallbackNames, fallbackLens, fallbackStarts);
        }

        static int GetMonthIndexByDay(int dayOfYear, int[] monthStarts, int[] monthLengths)
        {
            for (int i = 0; i < 12; i++)
            {
                int start = monthStarts[i];
                int end = start + monthLengths[i] - 1;
                if (dayOfYear >= start && dayOfYear <= end) return i;
            }
            if (dayOfYear < monthStarts[0]) return 0;
            return 11;
        }

        static List<Booking> ReadBookings(string path)
        {
            var bookings = new List<Booking>();

            var lines = File.ReadAllLines(path)
                            .Select(l => l.Trim())
                            .Where(l => l.Length > 0)
                            .ToList();

            if (lines.Count == 0)
                throw new IOException("Üres pitypang.txt.");

            int n = int.Parse(lines[0], CultureInfo.InvariantCulture);

            for (int i = 1; i < lines.Count && bookings.Count < n; i++)
            {
                string[] parts = lines[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                // var parts = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 7) continue;

                bookings.Add(new Booking
                {
                    Id = int.Parse(parts[0], CultureInfo.InvariantCulture),
                    Room = int.Parse(parts[1], CultureInfo.InvariantCulture),
                    Arrival = int.Parse(parts[2], CultureInfo.InvariantCulture),
                    Departure = int.Parse(parts[3], CultureInfo.InvariantCulture),
                    Guests = int.Parse(parts[4], CultureInfo.InvariantCulture),
                    Breakfast = int.Parse(parts[5], CultureInfo.InvariantCulture),
                    NameId = parts[6]
                });
            }

            return bookings;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Booking> bookings;

            Console.WriteLine("1. feladat:");
            try
            {
                bookings = ReadBookings("pitypang.txt");
                Console.WriteLine($"Beolvasva: {bookings.Count} foglalás.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nem sikerült beolvasni a pitypang.txt fájlt.");
                Console.WriteLine("Hiba: " + ex.Message);
                Console.WriteLine("Tedd a pitypang.txt fájlt a futtatható program mellé, majd indítsd újra.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("2. feladat:");
            // Use FirstOrDefault to avoid exception when there are no bookings
            var longest = bookings.OrderByDescending(b => b.Nights).FirstOrDefault();
            if (longest == null)
            {
                Console.WriteLine("Nincs foglalás, ezért a leghosszabb tartózkodás nem megállapítható.");
            }
            else
            {
                Console.WriteLine($"{longest.NameId} ({longest.Arrival}) – {longest.Nights}");
            }

            Console.WriteLine();
            Console.WriteLine("3. feladat:");
            long totalRevenue = 0;
            var outLines = new List<string>(bookings.Count);

            foreach (var b in bookings)
            {
                int cost = CalcBookingCost(b);
                totalRevenue += cost;
                outLines.Add($"{b.Id}:{cost}");
            }

            try
            {
                File.WriteAllLines("bevetel.txt", outLines);
                Console.WriteLine("A bevetel.txt fájl elkészült.");
            }
            catch
            {
                Console.WriteLine("Nem sikerült a bevetel.txt fájlba írni. Az első 10 foglalás díja:");
                foreach (var line in outLines.Take(10))
                    Console.WriteLine(line);
            }

            Console.WriteLine($"A szálloda teljes évi bevétele: {totalRevenue} Ft");

            Console.WriteLine();
            Console.WriteLine("4. feladat:");
            var months = ReadMonthsOrFallback("honapok.txt");
            int[] guestNightsByMonth = new int[12];

            foreach (var b in bookings)
            {
                for (int day = b.Arrival; day <= b.Departure - 1; day++)
                {
                    int mi = GetMonthIndexByDay(day, months.monthStarts, months.monthLengths);
                    guestNightsByMonth[mi] += b.Guests;
                }
            }

            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine($"{i + 1}: {guestNightsByMonth[i]} vendégéj");
            }

            Console.WriteLine();
            Console.WriteLine("5. feladat:");
            Console.Write("Kérem az új foglalás kezdő napjának sorszámát: ");
            int startDay = int.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);

            Console.Write("Kérem az eltöltendő éjszakák számát: ");
            int nightsWanted = int.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);

            int endDay = startDay + nightsWanted;

            int freeRooms = 0;
            for (int room = 1; room <= 27; room++)
            {
                bool overlaps = bookings.Any(b =>
                    b.Room == room &&
                    b.Arrival < endDay &&
                    b.Departure > startDay
                );

                if (!overlaps) freeRooms++;
            }

            Console.WriteLine($"A megadott időszak teljes tartamában szabad szobák száma: {freeRooms}");
        }
    }
}