namespace Tests
{
    public  class Limit
    {
        public Limit(double startDistance, double cost)
        {
            this.StartDistance = startDistance;
            this.Cost = cost;
        }

        public double StartDistance { get; }
        public double Cost { get; }
    }
}