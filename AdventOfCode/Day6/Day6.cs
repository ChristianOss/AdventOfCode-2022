using System;

namespace AdventOfCode.Days
{
    public class Day6 : IProcess
    {
        public Task ExecuteAsync()
        {
            PrintAnswer();
            return Task.CompletedTask; 
        }

        private void PrintAnswer()
        {
            var message = File.ReadAllText(@"Data/Day6Input.txt");
            var part1Result = GetStartOfPacketMarker(message, 4);
            var part2Result = GetStartOfPacketMarker(message, 14);

            Console.WriteLine($"Part 1 result: {part1Result}");
            Console.WriteLine($"Part 2 result: {part2Result}");
        }

        private int GetStartOfPacketMarker(string message, int groupSize)
        {
            for(int i = 0; i < message.Length; ++i)
            {
                var group = message.Substring(i, Math.Min(groupSize, message.Length - i)).Distinct();

                if (group.Count() == groupSize)
                {
                    return i + groupSize;
                }
            }

            return -1;
        }
    }
}
