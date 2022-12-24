namespace AdventOfCode.Day1
{
    public class Day1 : IProcess
    {
        public Task ExecuteAsync()
        {
            PrintAnswer();
            return Task.CompletedTask; 
        }

        public void PrintAnswer()
        {
            var allMeals = File.ReadAllText(@"Data/Day1CaloriesInput.txt").Split("\r\n\r\n");
            var totalCaloriesPerElf = new List<int>();
            foreach(var elfMeals in allMeals)
            {
                var meals = elfMeals.Split("\n");
                int calorieCounter = 0;
                foreach(var calorieCount in meals)
                {
                    calorieCounter += int.Parse(calorieCount);
                }

                totalCaloriesPerElf.Add(calorieCounter);
            }

            var topThree = totalCaloriesPerElf.OrderByDescending(calories => calories).Take(3);

            Console.WriteLine($"Most calories: {totalCaloriesPerElf.Max()}");
            Console.WriteLine($"Top 3 most calories total: {topThree.Sum()}");
        }


    }
}
