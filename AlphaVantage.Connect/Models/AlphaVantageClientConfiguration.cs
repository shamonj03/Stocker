namespace AlphaVantage.Connect.Models
{
    public class AlphaVantageClientConfiguration
    {
        public string ApiKey { get; set; }

        public string Url { get; set; }

        public string ClientName { get; set; }

        public AlphaVantageClientConfiguration()
        {
            ApiKey = "demo";
            ClientName = "AlphaVantageClient";
            Url = "https://www.alphavantage.co";
        }
    }
}
