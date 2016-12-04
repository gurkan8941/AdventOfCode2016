using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Room
    {
        private string _input;

        public Room(string input)
        {
            _input = input;

        }

        public string CheckSum
        {
            get
            {
                var indexOfBracket = _input.IndexOf('[');
                var checksum = _input.Substring(indexOfBracket + 1).TrimEnd(new char[] { ']' });
                return checksum;
            }
        }

        public long SectorId
        {
            get
            {
                var indexOfDash = _input.LastIndexOf('-');
                var sectorId = _input.Substring(indexOfDash + 1).Split(new char[] { '[' })[0];
                return Int64.Parse(sectorId);
            }
        }

        public string RoomName
        {
            get
            {
                var indexOfDash = _input.LastIndexOf('-');
                var roomName = _input.Substring(0, indexOfDash + 1);
                return roomName;
            }
        }

        private string CalculateChecksum()
        {
            var cleanRoomName = RoomName.Replace("-", "");
            var dictionary = new Dictionary<char, int>();
            foreach (var c in cleanRoomName)
            {
                if (dictionary.ContainsKey(c))
                    dictionary[c] = dictionary[c] + 1;
                else
                    dictionary.Add(c, 1);
            }

            var ordered = dictionary.OrderByDescending(d => d.Value).ThenBy(d => (int)d.Key);
            var checksum = new string(ordered.Take(5).Select(d => d.Key).ToArray());

            return checksum;
        }


        public bool IsReal()
        {
            var calculatedChecksum = CalculateChecksum();
            return calculatedChecksum == CheckSum;
        }
    }
}
