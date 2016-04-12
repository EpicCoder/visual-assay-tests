using android_test.ActivityElement;

namespace android_test.ActivityRepo.Browser
{
    class FlowCreateDialog
    {
        static string ActivityName = "Flow Create Dialog";

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

        public static AndroidEditText FlowName
        {
            get
            {
                string id = "text_edit";
                string name = "Flow Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }
    }
}
