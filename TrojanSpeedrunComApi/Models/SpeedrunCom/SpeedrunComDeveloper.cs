namespace TrojanSpeedrunComApi.Models
{
    public class SpeedrunComDeveloper
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<DeveloperLinks> links { get; set; }
    }
    public class DeveloperLinks
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }
    public class DeveloperWrapper
    {
        public SpeedrunComDeveloper data { get; set; }
    }
}
