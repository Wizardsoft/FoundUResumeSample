using System;
using System.IO;
using Newtonsoft.Json;
using RestSharp;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p = new Params
            {
                Resume = System.Text.Encoding.Default.GetString(File.ReadAllBytes(@"c:\temp\resume.pdf"))
            };

            SendResume(123, p, "rw-sandbox", "TOKEN");
        }


        public static void SendResume(int employeeId, Params param, string subdomain, string token)
        {
            var client = new RestClient($"https://{subdomain}.foundu.com.au/api");
            var request = new RestRequest($"v2/employees/{employeeId}/upload-resume", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/json", JsonConvert.SerializeObject(param), ParameterType.RequestBody);

            var response = client.PostAsync(request).Result;

            Console.WriteLine(response.Content);
        }
    }
}
