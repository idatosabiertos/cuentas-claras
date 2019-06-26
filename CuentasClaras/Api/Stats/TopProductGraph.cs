namespace CuentasClaras.Api.Stats
{
    public class TopGraph
    {
        public string Description { get; set; }
        public decimal Q1 { get; set; }
        public decimal Q3 { get; set; }
        public decimal Median { get; set; }
        public decimal Mean { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public string DescriptionLong { get; internal set; }
    }
}
