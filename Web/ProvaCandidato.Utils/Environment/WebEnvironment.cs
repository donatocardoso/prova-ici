using System;
using System.Configuration;

namespace ProvaCandidato.Utils.Environment
{
    public enum WebEnvironmentType
    {
        PRODUCTION,
        STAGING,
        DEVELOPER
    }

    public static class WebEnvironment
    {
        public static bool IsProduction => Environment == WebEnvironmentType.PRODUCTION;
        public static bool IsStaging => Environment == WebEnvironmentType.STAGING;
        public static bool IsDevelopment => Environment == WebEnvironmentType.DEVELOPER;

        // App Settings

        public static WebEnvironmentType Environment => (WebEnvironmentType)Enum.Parse(typeof(WebEnvironmentType), ConfigurationManager.AppSettings.Get("Environment"));
        public static string ApiProvaCandidato => ConfigurationManager.AppSettings.Get("ApiProvaCandidato");
        public static string NomeEmpresa => ConfigurationManager.AppSettings.Get("NomeEmpresa");

        // Environment Variables

    }
}
