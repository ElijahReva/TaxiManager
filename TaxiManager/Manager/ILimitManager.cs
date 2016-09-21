namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Manage rate limits.
    /// </summary>
    public interface ILimitManager
    {
        /// <summary>
        /// Sets  the rate limits.
        /// </summary>
        /// <value>
        /// Limits.
        /// </value>
        IReadOnlyList<Limit> Limits { get; }

        /// <summary>
        /// Find closest bottom rate per km, if no limits set return <seealso cref="DefaultCost"/>
        /// </summary>
        /// <param name="distance">Distance.</param>
        /// <returns>Finded limit.</returns>
        Limit FindLimit(double distance);
    }

    public class LimitManager : ILimitManager
    {

        private readonly Configuration config;

        public LimitManager(Configuration config, IReadOnlyList<Limit> limits)
        {
            this.config = config;
            this.Limits = limits;
        }

        public Limit FindLimit(double distance)
        {
            var closestLimit = new Limit(0, this.config.BaseRate); // This is default cost per KM
            var minDifference = Double.MinValue;
            foreach (var element in this.Limits.TakeWhile(l => l.StartDistance < distance))
            {
                var difference = element.StartDistance - distance;
                if (minDifference < difference)
                {
                    minDifference = difference;
                    closestLimit = element;
                }
            }

            return closestLimit;
        }

        public IReadOnlyList<Limit> Limits { get; }

    }
}