namespace AkademiPlusMikroServiceProject.Frontend.Models
{
    public class ClientSettings
    {
        public Client WebClient { get; set; }
        public Client WebClientForUser { get; set; }
        public class Client
        {
            public string ClientID { get; set; }
            public string ClientSecret { get; set; }
        }
    }
}
