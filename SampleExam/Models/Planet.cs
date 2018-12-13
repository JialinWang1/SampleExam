using Newtonsoft.Json;

namespace SampleExam
{
    public class Planet
    {
        [JsonIgnore]
        public long PlanetID { get; set; }
        public long Population { get; set; }
        public string PlanetName { get; set; }
    }
}