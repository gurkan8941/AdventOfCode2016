using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var allRooms = ReadAllLines("input.txt").Select(l => new Room(l));
            var realRooms = allRooms.Where(r => r.IsReal());
            var sectorIdSum = realRooms.Sum(r => r.SectorId);

            Console.WriteLine($"The sectorId sum is {sectorIdSum}");


            var northpoleObjectRoom = realRooms.SingleOrDefault(r => r.DecryptedRoomName.Contains("northpole object"));

            Console.WriteLine($"{northpoleObjectRoom.DecryptedRoomName} has sectorId {northpoleObjectRoom.SectorId}");
            Console.ReadLine();

        }

        private static string[] ReadAllLines(string fileName)
        {
            var path = Path.Combine(Environment.CurrentDirectory, fileName);
            var text = File.ReadAllLines(path);
            return text;
        }
    }
}
