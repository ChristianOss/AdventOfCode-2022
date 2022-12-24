namespace AdventOfCode.Days
{
    public class Day2 : IProcess
    {
        private const int LossScore = 0, DrawScore = 3, WinScore = 6;
        private const int RockChosenScore = 1, PaperChosenScore = 2, ScissorsChosenScore = 3;

        private const char OpponentRock = 'A', OpponentPaper = 'B', OpponentScissors = 'C';
        private const char MyRock = 'X', MyPaper = 'Y', MyScissors = 'Z';
        private const char IShouldLose = 'X', IShouldDraw = 'Y', IShouldWin = 'Z';

        public Task ExecuteAsync()
        {
            PrintAnswerPart1();
            PrintAnswerPart2();
            return Task.CompletedTask; 
        }

        private void PrintAnswerPart1()
        {
            var rounds = File.ReadAllText(@"Data/Day2Input.txt").Split("\n");
            var myTotalScore = 0;

            foreach(var round in rounds)
            {
                var choices = round.Split(" ");
                var opponentChoice = choices[0][0];
                var myChoice = choices[1][0];
                myTotalScore += GetRoundScorePart1(opponentChoice, myChoice);
            }

            Console.WriteLine($"My total score part 1: {myTotalScore}");
        }

        private int GetRoundScorePart1(char opponentChoice, char myChoice)
        {
            var roundScore = 0;

            switch (myChoice)
            {
                case MyRock:
                    switch (opponentChoice)
                    {
                        case OpponentRock:
                            roundScore += DrawScore;
                            break;
                        case OpponentPaper:
                            roundScore += LossScore;
                            break;
                        case OpponentScissors:
                            roundScore += WinScore;
                            break;
                    }

                    roundScore += RockChosenScore;
                    break;
                case MyPaper:
                    switch (opponentChoice)
                    {
                        case OpponentRock:
                            roundScore += WinScore;
                            break;
                        case OpponentPaper:
                            roundScore += DrawScore;
                            break;
                        case OpponentScissors:
                            roundScore += LossScore;
                            break;
                    }

                    roundScore += PaperChosenScore;
                    break;
                case MyScissors:
                    switch (opponentChoice)
                    {
                        case OpponentRock:
                            roundScore += LossScore;
                            break;
                        case OpponentPaper:
                            roundScore += WinScore;
                            break;
                        case OpponentScissors:
                            roundScore += DrawScore;
                            break;
                    }

                    roundScore += ScissorsChosenScore;
                    break;
            }

            return roundScore;
        }

        private void PrintAnswerPart2()
        {
            var rounds = File.ReadAllText(@"Data/Day2Input.txt").Split("\n");
            var myTotalScore = 0;

            foreach (var round in rounds)
            {
                var choices = round.Split(" ");
                var opponentChoice = choices[0][0];
                var myChoice = choices[1][0];
                myTotalScore += GetRoundScorePart2(opponentChoice, myChoice);
            }

            Console.WriteLine($"My total score part 2: {myTotalScore}");
        }

        private int GetRoundScorePart2(char opponentChoice, char myChoice)
        {
            var roundScore = 0;

            switch(myChoice)
            {
                case IShouldWin:
                    switch(opponentChoice)
                    {
                        case OpponentRock:
                            roundScore += PaperChosenScore;
                            break;
                        case OpponentPaper:
                            roundScore += ScissorsChosenScore;
                            break;
                        case OpponentScissors:
                            roundScore += RockChosenScore;
                            break;
                    }

                    roundScore += WinScore;
                    break;
                case IShouldDraw:
                    switch (opponentChoice)
                    {
                        case OpponentRock:
                            roundScore += RockChosenScore;
                            break;
                        case OpponentPaper:
                            roundScore += PaperChosenScore;
                            break;
                        case OpponentScissors:
                            roundScore += ScissorsChosenScore;
                            break;
                    }

                    roundScore += DrawScore;
                    break;
                case IShouldLose:
                    switch (opponentChoice)
                    {
                        case OpponentRock:
                            roundScore += ScissorsChosenScore;
                            break;
                        case OpponentPaper:
                            roundScore += RockChosenScore;
                            break;
                        case OpponentScissors:
                            roundScore += PaperChosenScore;
                            break;
                    }

                    roundScore += LossScore;
                    break;
            }

            return roundScore;
        }


    }
}
