using System.Configuration;

namespace android_test
{
    class Settings
    {
        private static Settings _instance;

        public string AppPath { get; private set; }

        public static Settings Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                return _instance = new Settings();
            }
        }

        private Settings()
        {
            AppPath = ConfigurationManager.AppSettings["appPath"];
        }
    }
}
