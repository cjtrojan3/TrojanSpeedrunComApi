using Newtonsoft.Json;

namespace TrojanSpeedrunComApi.Framework.Extensions
{
    public static class JsonExtensions
    {
        public static T FromJson<T>(this string json)
        {
            if (json.IsNullOrEmpty())
                return default;

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
