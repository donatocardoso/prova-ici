using System;
using System.Configuration;

namespace ProvaCandidato.Utils.Environment
{
    public enum ApiEnvironmentType
    {
        PRODUCTION,
        STAGING,
        DEVELOPER
    }

    public static class ApiEnvironment
    {
        public static bool IsProduction => Environment == ApiEnvironmentType.PRODUCTION;
        public static bool IsStaging => Environment == ApiEnvironmentType.STAGING;
        public static bool IsDevelopment => Environment == ApiEnvironmentType.DEVELOPER;

        // Connection Strings

        public static string CnnDbProvaCandidato => ConfigurationManager.ConnectionStrings["DbProvaCandidato"].ToString();

        // App Settings

        public static ApiEnvironmentType Environment => (ApiEnvironmentType)Enum.Parse(typeof(ApiEnvironmentType), ConfigurationManager.AppSettings.Get("Environment"));

        // Environment Variables

    }
}
