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
    }
}
