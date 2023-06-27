namespace CQRSDemoFrontend.Models
{
    public class ApiService
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7010");
            return Client;
        }
    }
}