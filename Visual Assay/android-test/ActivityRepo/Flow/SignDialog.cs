using android_test.ActivityElement;

namespace android_test.ActivityRepo.Flow
{
    class SignDialog
    {
        static string ActivityName = "Flow Sign Dialog";

        public static AndroidButton Ok
        {
            get
            {
                string id = "signature_button_ok";
                string name = "Ok";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton DrawArea
        {
            get
            {
                string id = "signature";
                string name = "Draw Area";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
