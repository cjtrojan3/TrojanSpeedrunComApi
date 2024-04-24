namespace TrojanSpeedrunComApi.Framework.Helpers
{
    public class EnvironmentHelper
    {
        protected IConfiguration _configuration { get; private set; }

        public EnvironmentHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetAppSetting(AppSettings appSetting)
        {
            return _configuration.GetSection(appSetting.ToString()).Value;
        }

        public enum AppSettings
        {
            SpeedrunComApiBaseUrl
        }
    }
}
