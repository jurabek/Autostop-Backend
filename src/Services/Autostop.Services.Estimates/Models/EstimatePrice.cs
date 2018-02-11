namespace Autostop.Services.Estimates.Models
{
    public class EstimatePrice
    {
	    public int HighEstimate { get; set; }

	    public int LowEstimate { get; set; }

	    public string CurrencyCode { get; set; }

	    public string Estimate { get; set; }

	    public float Distance { get; set; }

	    public int Duration { get; set; }
    }
}
