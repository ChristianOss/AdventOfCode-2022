namespace AdventOfCode.Days
{
    public class Day4 : IProcess
    {
        public Task ExecuteAsync()
        {
            PrintAnswer();
            return Task.CompletedTask; 
        }

        private void PrintAnswer()
        {
            var pairs = File.ReadAllLines(@"Data/Day4Input.txt");
            var fullOverlapCount = 0;
            var overlapCount = 0;

            foreach(var pair in pairs)
            {
                var assignments = pair.Split(",");
                var firstRange = assignments[0].Split("-");
                var assignmentA = new Range(int.Parse(firstRange[0].ToString()), int.Parse(firstRange[1].ToString()));
                var secondRange = assignments[1].Split("-");
                var assignmentB = new Range(int.Parse(secondRange[0].ToString()), int.Parse(secondRange[1].ToString()));
                fullOverlapCount += RangesFullyContain(assignmentA, assignmentB);
                overlapCount += RangesOverlap(assignmentA, assignmentB);
            }

            Console.WriteLine($"Full overlap count: {fullOverlapCount}");
            Console.WriteLine($"Overlap count: {overlapCount}");
        }

        private int RangesFullyContain(Range a, Range b)
        {
            return (a.Start.Value <= b.Start.Value && a.End.Value >= b.End.Value) ||
                (b.Start.Value <= a.Start.Value && b.End.Value >= a.End.Value) ? 1 : 0;
        }

        private int RangesOverlap(Range a, Range b)
        {
            return (a.Start.Value <= b.End.Value && b.Start.Value <= a.End.Value) ? 1 : 0;
        }
    }
}
