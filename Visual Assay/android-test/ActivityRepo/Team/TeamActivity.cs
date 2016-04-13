using System;
using android_test.ActivityElement;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;

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

        public static void AddUserToTeam(string userName)
        {
            try
            {
                AndroidElement dragItem = UserList.FindElement(userName);
                AndroidElement dropItem = TeamMemberList.GetInternalElement();
                TouchAction action = new TouchAction(Appium.Instance.Driver);
                action.Press(dragItem).Wait(1500).MoveTo(dropItem).Release().Perform();
                ConsoleMessage.Pass(String.Format("{0}. Drag user with name: {1} and drop to team", ActivityName, userName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't drag user with name: {1} and drop to team", ActivityName, userName), ex);
                throw;
            }
        }
    }
}
