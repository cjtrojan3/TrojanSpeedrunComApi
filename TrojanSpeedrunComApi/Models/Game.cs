namespace TrojanSpeedrunComApi.Models
{
    public class Game
    {
        public string Id { get; set; }
        public int YearReleased { get; set; }
        public string Name { get; set; }
        public List<string> DeveloperIds { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }

        public static Game MapFrom(SpeedrunComGame source)
        {
            return new Game
            {
                Id = source.id,
                YearReleased = source.released,
                Name = source.names.international,
                DeveloperIds = source.developers.ToList(),
                CreatedDate = source.created
            };
        }
    }
}
