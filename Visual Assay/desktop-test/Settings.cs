using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using desktop_test.Entity;

namespace desktop_test
{
    class Settings
    {
        private static Settings _instance;

        public string AppPath { get; private set; }
        public string Team { get; private set; }
        public string TeamRemove { get; private set; }
        public User User1 { get; private set; }
        public User User2 { get; private set; }
        public User User3 { get; private set; }
        //test setting
        public int LoginDelay { get; private set; }
        public int LoginTimeout { get; private set; }
        public int InitTimeout { get; private set; }
        public int ShareDelay { get; private set; }
        public string Version { get; private set; }

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
            User1 = new User(ConfigurationManager.AppSettings["userName1"],
                ConfigurationManager.AppSettings["userPass1"]);
            User2 = new User(ConfigurationManager.AppSettings["userName2"],
                ConfigurationManager.AppSettings["userPass2"]);
            User3 = new User(ConfigurationManager.AppSettings["userName3"],
                ConfigurationManager.AppSettings["userPass3"]);
            LoginDelay = Convert.ToInt32(ConfigurationManager.AppSettings["loginDelay"]);
            ShareDelay = Convert.ToInt32(ConfigurationManager.AppSettings["shareDelay"]);
            LoginTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeout"]);
            InitTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["initTimeout"]);
            Version = ConfigurationManager.AppSettings["version"];
            var team = ConfigurationManager.AppSettings["team"];
            Team = String.Format("!{0}-{1}", Version, team);
            TeamRemove = ConfigurationManager.AppSettings["teamRemove"];
        }
    }
}
