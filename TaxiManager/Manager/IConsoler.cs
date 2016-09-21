namespace Tests
{
    using System;

    public interface IConsoler
    {
        /// <summary>
        /// Gets info about night from user.
        /// </summary>
        /// <returns>Is it night right now.</returns>
        bool AskAboutNight();

        /// <summary>
        /// Gets info about distance from user.
        /// </summary>
        /// <returns></returns>
        double AskAboutDistance();

        /// <summary>
        /// Writes the paycheck.
        /// </summary>
        /// <param name="cost">Total cost.</param>
        void WriteCheck(double cost);
    }

    public class Consoler : IConsoler
    {
        private readonly Configuration config;

        public Consoler(Configuration config)
        {
            this.config = config;
        }

        public bool AskAboutNight()
        {

            var input = this.AskQuestion(
                $"Is it night time right now? (Print - '{this.config.YesAnswer}' or '{this.config.NoAnswer}') ",
                $"Provided input doesn't look like '{this.config.YesAnswer}' or '{this.config.NoAnswer}'. Try once again.",
                this.CheckAnswer);
            return input != this.config.NoAnswer;

        }

        private bool CheckAnswer(string s)
        {
            return string.Equals(s, this.config.YesAnswer, StringComparison.OrdinalIgnoreCase) || string.Equals(s, this.config.NoAnswer, StringComparison.OrdinalIgnoreCase);
        }

        private string AskQuestion(string questionText, string inputErrorText, Func<string, bool> validator)
        {
            var backupColor = Console.ForegroundColor;
            string input;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(questionText);
                Console.ForegroundColor = backupColor;

                input = Console.ReadLine();
                if (!validator(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(inputErrorText);
                    Console.ForegroundColor = backupColor;
                    continue;
                }
                break;
            }

            return input;
        }

        public double AskAboutDistance()
        {
            double distance = 0d;
            var input = this.AskQuestion(
               "Enter distance as float number.",
               "Provided input doesn't look like float number. Try once again.",
               s => double.TryParse(s, out distance));

            //return distance;
            return double.Parse(input);
        }

        public void WriteCheck(double cost)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine($"Total cost of your trip: [{cost:0.00}]");
            Console.ForegroundColor = color;
            Console.WriteLine();
        }
    }
}