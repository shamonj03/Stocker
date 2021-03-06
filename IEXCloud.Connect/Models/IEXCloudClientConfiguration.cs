namespace IEXCloud.Connect.Models
{
    public class IEXCloudClientConfiguration
    {
        public string ApiKey { get; set; }

        public string Url { get; set; }

        public string ClientName { get; set; }

        public IEXCloudClientConfiguration()
        {
            ApiKey = "demo";
            ClientName = "IEXCloudClient";
            Url = "https://cloud.iexapis.com";
        }
    }
}
