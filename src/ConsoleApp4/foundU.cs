using Newtonsoft.Json;

namespace ConsoleApp4
{
    public class Result_Generic
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }

    public class Params
    {
        [JsonProperty("resume_file")]
        public string Resume { get; set; }
    }
}