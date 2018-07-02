namespace AutofacDemo
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;
    using Model;
    using Extensions;

    public static class AppSettings
    {
        private const string DefaultSettingsFileUrl = "";

        private static ISettings Settings => CrossSettings.Current;

        public static string SettingsFileUrl
        {
            get => Settings.GetValueOrDefault(nameof(SettingsFileUrl), DefaultSettingsFileUrl);

            set => Settings.AddOrUpdateValue(nameof(SettingsFileUrl), value);
        }

        public static User User
        {
            get => Settings.GetValueOrDefault(nameof(User), default(User));

            set => Settings.AddOrUpdateValue(nameof(User), value);
        }

        public static void RemoveUserData()
        {
            Settings.Remove(nameof(User));
        }
    }
}
