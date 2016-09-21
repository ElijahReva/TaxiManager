namespace Tests
{
    public class Configuration
    {
        public Configuration(double baseRate, double basePay, string yesAnswer, string noAnswer)
        {
            this.BaseRate = baseRate;
            this.BasePay = basePay;
            this.YesAnswer = yesAnswer;
            this.NoAnswer = noAnswer;
        }

        public double BaseRate { get;  }
        public double BasePay { get; }

        public string YesAnswer { get;  }

        public string NoAnswer { get;  }
    }
}