using System;

namespace DesignPatternPlayGround.Patterns
{
    public static class ProxyPattern
    {
        public static void Run()
        {
            Console.WriteLine("Proxy Pattern\n-----------------\n");

            IHttpClient httpClient = new HttpClientProxy();
            httpClient.Call();
        }
    }

    public interface IHttpClient
    {
        void Call();
    }

    public class HttpClient : IHttpClient
    {
        public void Call()
        {
            Console.WriteLine("Http call executed");
        }
    }

    public class HttpClientProxy : IHttpClient
    {
        private HttpClient httpClient;

        public void Call()
        {
            Console.WriteLine("Http call pre operations");

            httpClient = new HttpClient();
            httpClient.Call();

            Console.WriteLine("Http call post operations");
        }
    }
}
