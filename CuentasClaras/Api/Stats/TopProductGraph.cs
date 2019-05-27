namespace CuentasClaras.Api.Stats
{
    public class TopGraph
    {
        public string Description { get; set; }
        public double Q1 { get; set; }
        public double Q3 { get; set; }
        public double Median { get; set; }
        public double Mean { get; set; }
        public double Max { get; set; }
        public double Min { get; set; }
        public string DescriptionLong { get; internal set; }
    }
}
