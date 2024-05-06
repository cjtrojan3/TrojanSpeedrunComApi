namespace TrojanSpeedrunComApi.Models
{
    public class Game
    {
        public string Id { get; set; }
        public int YearReleased { get; set; }
        public string Name { get; set; }
        public List<string> DeveloperIds { get; set; } = new List<string>();
        public List<Developer> Developers { get; set; } = new List<Developer>();
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
