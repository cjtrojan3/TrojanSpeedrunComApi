namespace TrojanSpeedrunComApi.Models
{
    public class Game
    {
        public string Id { get; set; }
        public int YearReleased { get; set; }
        public string Name { get; set; }
        //public List<string> Platforms { get; set; }
        //public List<string> Regions { get; set; }
        public List<string> DeveloperIds { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
