namespace TrojanSpeedrunComApi.Models
{
    public class Developer
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public static Developer MapFrom(SpeedrunComDeveloper source)
        {
            return new Developer
            {
                Id = source.id,
                Name = source.name
            };
        }
    }
}
