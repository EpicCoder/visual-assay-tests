using System;
using android_test.ActivityElement;
using android_test.Entity;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;

namespace android_test.ActivityRepo.Library
{
    class LibraryShareDialog
    {
        static string ActivityName = "Library Share Dialog";

        public static AndroidList TeamList
        {
            get
            {
                string id = "teams";
                string name = "Team List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidList TeamMemberList
        {
            get
            {
                string id = "users";
                string name = "Team Member List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidList ShareWithList
        {
            get
            {
                string id = "shared_with";
                string name = "Share with List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidLabel DropHere
        {
            get
            {
                string id = "drag_here_text";
                string name = "Drop Here";
                return new AndroidLabel(id, name, ActivityName);
            }
        }

        public static AndroidButton Cancel
        {
            get
            {
                string id = "button_cancel";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Ok
        {
            get
            {
                string id = "button_share";
                string name = "Ok";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static void AddUser(string userName)
        {
            try
            {
                string selector =
                    "new UiScrollable(new UiSelector().resourceId(\"com.assayrt:id/users\")).scrollIntoView(text(\"" +
                    userName + "\"))";
                AndroidElement dragItem =
                    (AndroidElement) TeamMemberList.GetInternalElement().FindElementByAndroidUIAutomator(selector);
                AndroidElement dropItem = DropHere.GetInternalElement();
                TouchAction action = new TouchAction(Appium.Instance.Driver);
                action.Press(dragItem).Wait(1500).MoveTo(dropItem).Release().Perform();
                ConsoleMessage.Pass(String.Format("{0}. Drag user with name: {1} and drop to shareWith", ActivityName, userName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't drag user with name: {1} and drop to shareWith", ActivityName, userName), ex);
                throw;
            }
        }

        public static void AddTeam(string teamName)
        {
            try
            {
                string selector =
                    "new UiScrollable(new UiSelector().resourceId(\"com.assayrt:id/teams\")).scrollIntoView(text(\"" +
                    teamName + "\"))";
                AndroidElement dragItem =
                    (AndroidElement)TeamList.GetInternalElement().FindElementByAndroidUIAutomator(selector);
                AndroidElement dropItem = DropHere.GetInternalElement();
                TouchAction action = new TouchAction(Appium.Instance.Driver);
                action.Press(dragItem).Wait(1500).MoveTo(dropItem).Release().Perform();
                ConsoleMessage.Pass(String.Format("{0}. Drag team with name: {1} and drop to shareWith", ActivityName, teamName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't drag team with name: {1} and drop to shareWith", ActivityName, teamName), ex);
                throw;
            }
        }

        public static void Unshare(string shareWith)
        {
            try
            {
                AndroidElement dragItem = (AndroidElement) ShareWithList.GetInternalElement().FindElementByName(shareWith);
                AndroidElement dropItem = TeamList.GetInternalElement();
                TouchAction action = new TouchAction(Appium.Instance.Driver);
                action.Press(dragItem).Wait(1500).MoveTo(dragItem).Wait(1500).MoveTo(dropItem).Wait(1500).Release();
                MultiAction multi = new MultiAction(Appium.Instance.Driver);
                multi.Add(action).Perform();
                ConsoleMessage.Pass(String.Format("{0}. Unshare. Drag user with name: {1} and drop to team", ActivityName, shareWith));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't unshare. Can't drag user with name: {1} and drop to team", ActivityName, shareWith), ex);
                throw;
            }
        }

        public static void SetPermission(Permission permission)
        {
            try
            {
                if (permission.View)
                    Appium.Instance.Driver.FindElementById("chk_view").Click();
                if (permission.Share)
                    Appium.Instance.Driver.FindElementById("chk_share").Click();
                if (permission.Modify)
                    Appium.Instance.Driver.FindElementById("chk_modify").Click();
                if (permission.Add)
                    Appium.Instance.Driver.FindElementById("chk_add").Click();
                ConsoleMessage.Pass(String.Format("{0}. Set permission", ActivityName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't set permission", ActivityName), ex);
                throw;
            }
        }

        public static void ShareWithUserStep(string teamName, string userName, Permission permission)
        {
            TeamList.FindAndTap(teamName);
            TeamMemberList.FindAndTap(userName);
            AddUser(userName);
            ShareWithList.VerifyElementCountById(1, "user_picture");
            SetPermission(permission);
            Ok.Tap();
        }

        public static void ShareWithTeamStep(string teamName, Permission permission)
        {
            TeamList.FindAndTap(teamName);
            AddTeam(teamName);
            ShareWithList.VerifyElementCountById(1, "user_picture");
            SetPermission(permission);
            Ok.Tap();
        }
    }
}
