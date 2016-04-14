using System;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Browser
{
    class FlowTypeDialog
    {
        static string ActivityName = "Flow Type Dialog";

        public static AndroidList FlowType
        {
            get
            {
                string id = "select_dialog_listview";
                string name = "Flow Type List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static void SelectFlowPlan()
        {
            try
            {
                FlowType.GetInternalElement().FindElementByName("Flow Plan").Click();
                ConsoleMessage.Pass(String.Format("{0}. Select: Flow Plan", ActivityName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't Select: Flow Plan", ActivityName), ex);
                throw;
            }
        }


    }
}
