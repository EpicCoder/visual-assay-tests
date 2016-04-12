using android_test.ActivityElement;

namespace android_test.ActivityRepo.Library
{
    class LibraryPermissionErrorDialog
    {
        static string ActivityName = "Library Permission Error Dialog";

        public static AndroidLabel DialogName
        {
            get
            {
                string id = "alertTitle";
                string name = "Dialog Header";
                return new AndroidLabel(id, name, ActivityName);
            }
        }

        public static AndroidButton Ok
        {
            get
            {
                string id = "button1";
                string name = "Ok";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
