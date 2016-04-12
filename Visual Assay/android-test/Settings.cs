using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
