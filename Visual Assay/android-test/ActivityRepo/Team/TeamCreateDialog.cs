using android_test.ActivityElement;

namespace android_test.ActivityRepo.Team
{
    class TeamCreateDialog
    {
        static string ActivityName = "Team Create Dialog";

        public static AndroidButton Cancel
        {
            get
            {
                string id = "button2";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Create
        {
            get
            {
                string id = "button1";
                string name = "Create";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText TeamName
        {
            get
            {
                string id = "team_name";
                string name = "Team Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }
    }
}
