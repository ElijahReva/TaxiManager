namespace Tests
{
    public class TaxiManager
    {
        private readonly ILimitManager limits;

        private readonly Configuration config;

        public TaxiManager(ILimitManager limits,  Configuration config)
        {
            this.limits = limits;
            this.config = config;
        }

        /// <summary>
        /// Calculate total cost based on distance.
        /// </summary>
        /// <param name="distance">Distance.</param>
        /// <param name="isNight">Indicates about night right now.</param>
        /// <returns></returns>
        public double TotalCost(double distance, bool isNight)
        {
            var nearest = this.limits.FindLimit(distance);
            var totalCost = this.config.BasePay + distance * NightModifyer(nearest.Cost, isNight);
            return totalCost;
        }
        /// <summary>
        /// Modify cost depending on night-time.
        /// </summary>
        /// <param name="input">Total cost.</param>
        /// <param name="isNight">If set to <c>true</c> cost divided by 2.</param>
        /// <returns></returns>
        private static double NightModifyer(double input, bool isNight)
        {
            return isNight ? input / 2 : input;
        }
    }
}