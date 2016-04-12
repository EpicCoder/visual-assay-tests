using android_test.ActivityElement;

namespace android_test.ActivityRepo.Team
{
    class TeamActivity
    {
        static string ActivityName = "Team Activity";

        public static AndroidList TeamList
        {
            get
            {
                string id = "teams_list";
                string name = "Team List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidList TeamMemberList
        {
            get
            {
                string id = "team_members";
                string name = "Team Member List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidList UserList
        {
            get
            {
                string id = "users";
                string name = "User List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidButton NewTeam
        {
            get
            {
                string id = "new_team_button";
                string name = "New Team";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Dismiss
        {
            get
            {
                string id = "team_dismiss_button";
                string name = "Team Dismiss";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
