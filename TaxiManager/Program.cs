namespace Tests
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private const double BasePay = 30;
        private const double BaseCost = 5;
        private const string YesAnswer = "Yes";
        private const string NoAnswer = "No";

        private static void Main()
        {
            var limits = new List<Limit>
                             {
                                 new Limit(10, 4),
                                 new Limit(20, 3)
                             };

            var config = new Configuration(BaseCost, BasePay, YesAnswer, NoAnswer);
            var limitManager = new LimitManager(config, limits.AsReadOnly());
            var consoler = new Consoler(config);
            var taxiManager = new TaxiManager(limitManager, config);
            var distance = consoler.AskAboutDistance();
            var isNight = consoler.AskAboutNight();
            var totalCost = taxiManager.TotalCost(distance, isNight);
            consoler.WriteCheck(totalCost);
            
            Console.ReadLine();
        }
    }
}
