namespace AdventOfCode.Days
{
    public class Day3 : IProcess
    {
        private IDictionary<char, int> priorities = new Dictionary<char, int>();

        public Task ExecuteAsync()
        {
            DefinePriorities();
            PrintAnswer();
            return Task.CompletedTask; 
        }

        private void DefinePriorities()
        {
            var priority = 1;

            for (var letter = 'a'; letter <= 'z'; letter++)
            {
                priorities[letter] = priority;
                priority++;
            }

            for (var letter = 'A'; letter <= 'Z'; letter++)
            {
                priorities[letter] = priority;
                priority++;
            }
        }

        private void PrintAnswer()
        {
            var rucksacks = File.ReadAllText(@"Data/Day3Input.txt").Split("\r\n");
            var prioritiesSum = 0;

            foreach(var rucksack in rucksacks)
            {
                var compartment1 = rucksack.Substring(0, rucksack.Length / 2);
                var compartment2 = rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2);
                prioritiesSum += compartment1
                    .Intersect(compartment2)
                    .Sum(character => priorities[character]);
            }

            var badgePrioritiesSum = 0;
            for (int i = 0; (i + 3) <= rucksacks.Length; i += 3)
            {
                var rucksackGroup = rucksacks.Skip(i).Take(3);

                IEnumerable<char> commonItems = rucksackGroup.First();
                foreach(var rucksack in rucksackGroup.Skip(1))
                {
                    commonItems = commonItems.Intersect(rucksack);
                }

                badgePrioritiesSum += commonItems.Sum(character => priorities[character]);
            }

            Console.WriteLine($"Sum of priorities: {prioritiesSum}");
            Console.WriteLine($"Sum of badge priorities: {badgePrioritiesSum}");
        }
    }
}
