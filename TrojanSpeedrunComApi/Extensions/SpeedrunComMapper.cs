using TrojanSpeedrunComApi.Models;

namespace TrojanSpeedrunComApi.Extensions
{
    public static class SpeedrunComMapper
    {
        public static Game MapGame(SpeedrunComGame source)
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

        public static Developer MapDeveloper(SpeedrunComDeveloper source)
        {
            return new Developer
            {
                Id = source.id,
                Name = source.name
            };
        }
    }
}
