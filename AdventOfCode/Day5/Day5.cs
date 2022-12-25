using AdventOfCode.Day5;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    public class Day5 : IProcess
    {
        private List<Stack<char>> StacksPart1 { get; } = new ();
        private List<Stack<char>> StacksPart2 { get; } = new();
        private Regex CommandRegex { get; } = new Regex("move (\\d+?) from (\\d+?) to (\\d+?)");

        public Task ExecuteAsync()
        {
            PrintAnswer();
            return Task.CompletedTask; 
        }

        private void PrintAnswer()
        {
            var inputParts = File.ReadAllText(@"Data/Day5Input.txt").Split("\r\n\r\n");
            var rows = inputParts[0].Split("\r\n");
            var columns = rows.Last();
            var crateRows = rows.SkipLast(1);
            var commands = inputParts[1].Split("\r\n"); ;

            for(int i = 1; i < columns.Length; i += 4)
            {
                StacksPart1.Add(new Stack<char>());
                StacksPart2.Add(new Stack<char>());
            }

            foreach(var crateRow in crateRows.Reverse())
            {
                int counter = 0;
                for (int i = 1; i < crateRow.Length; i += 4)
                {
                    if (char.IsLetter(crateRow[i]))
                    {
                        StacksPart1[counter].Push(crateRow[i]);
                        StacksPart2[counter].Push(crateRow[i]);
                    }
                    counter++;
                }
            }

            foreach(var command in commands)
            {
                var match = CommandRegex.Match(command);
                ExecuteCommand(new Command()
                {
                    Count = int.Parse(match.Groups[1].Value),
                    From = int.Parse(match.Groups[2].Value),
                    To = int.Parse(match.Groups[3].Value),
                });
            }

            var topOfEachStack = StacksPart1.Select(stack => stack.Peek());
            Console.WriteLine($"Top crate of each stack: {string.Join("", topOfEachStack)}");
            var topOfEachStackPart2 = StacksPart2.Select(stack => stack.Peek());
            Console.WriteLine($"Top crate of each stack: {string.Join("", topOfEachStackPart2)}");
        }

        private void ExecuteCommand(Command command)
        {
            var pickedCrates = new List<char>();
            for (int i = 0; i < command.Count; i++)
            {
                StacksPart1[command.To - 1].Push(StacksPart1[command.From - 1].Pop());
                pickedCrates.Add(StacksPart2[command.From - 1].Pop());
            }

            pickedCrates.Reverse();
            foreach (var crate in pickedCrates)
            {
                StacksPart2[command.To - 1].Push(crate);
            }
        }
    }
}
