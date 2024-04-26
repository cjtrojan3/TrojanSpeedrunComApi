namespace TrojanSpeedrunComApi.Models
{
    public class SpeedrunComGame
    {
        public string id { get; set; }
        public int released { get; set; }
        public GameNames names { get; set; }
        public string abbreviation { get; set; }
        public string[] platforms { get; set; }
        public string[] regions { get; set; }
        //public Assets assets { get; set; }
        public string[] developers { get; set; }
        public DateTimeOffset? created { get; set; }
    }
    public class GameNames
    {
        public string international { get; set; }
        //public string japanese { get; set; }
        //public string twitch { get; set; }
    }
    //public class Assets
    //{
    //    public SpeedrunDotComImage logo { get; set; }
    //}

    public class SpeedrunDotComImage
    {
        public string uri { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }

    public class GameWrapper
    {
        public SpeedrunComGame data { get; set; }
    }

    public class GameSearchWrapper
    {
        public List<SpeedrunComGame> data { get; set; }
    }
}
