using android_test.ActivityElement;

namespace android_test.ActivityRepo
{
    class TabMenu
    {
        static string ActivityName = "Tab Menu";

        public static AndroidButton Logout
        {
            get
            {
                string id = "menu_user";
                string name = "Logout";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Browser
        {
            get
            {
                string id = "menu_browser";
                string name = "Browser";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Library
        {
            get
            {
                string id = "menu_library";
                string name = "Library";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Pulse
        {
            get
            {
                string id = "menu_pulse";
                string name = "Pulse";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Teams
        {
            get
            {
                string id = "menu_teams";
                string name = "Teams";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Settings
        {
            get
            {
                string id = "menu_settings";
                string name = "Settings";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Search
        {
            get
            {
                string id = "menu_search";
                string name = "Search";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Archive
        {
            get
            {
                string id = "menu_archive";
                string name = "Archive";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
