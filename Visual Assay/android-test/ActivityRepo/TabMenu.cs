using System;
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

        public static void SearchItem(string name)
        {
            try
            {
                Appium.Instance.Driver.FindElementById("search_src_text").SendKeys(name + "\n");
                ConsoleMessage.Pass(String.Format("{0}. Find search textbox and enter searched name: {1}",
                    ActivityName, name));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format("{0}. Can't find search textbox and enter searched name: {1}", ActivityName, name), ex);
                throw;
            }
        }
    }
}
