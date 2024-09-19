using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public static class RonVSKanyeAPI
    {
        public static void Convo()
        {
            var client = new HttpClient();

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Kanye says:\n {GetKanyeQuote(client)}\n");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write(".");
                Console.WriteLine($"Ron says:\n {GetRonQuote(client)}\n");
                
            }
        }
        private static string GetKanyeQuote(HttpClient client)
        {
            var jsonText = client.GetStringAsync("https://api.kanye.rest/").Result;
            var quote = JObject.Parse(jsonText).GetValue("quote").ToString();

            return quote;
        }

        private static string GetRonQuote(HttpClient client)
        {
            var jsonText = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
            var quote = jsonText.Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();

            return quote;
        }
    }
}
