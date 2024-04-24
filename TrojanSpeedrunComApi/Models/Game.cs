namespace TrojanSpeedrunComApi.Models
{
    public class Game
    {
        public string id { get; set; }
        public int released { get; set; }
    }
    public class GameWrapper
    {
        public Game game { get; set; }
    }
}
