using android_test.ActivityElement;

namespace android_test.ActivityRepo.Browser
{
    class AssayDeleteDialog
    {
        static string ActivityName = "Assay Delete Dialog";

        public static AndroidButton Cancel
        {
            get
            {
                string id = "button2";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Delete
        {
            get
            {
                string id = "button1";
                string name = "Delete";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
