using android_test.ActivityElement;

namespace android_test.ActivityRepo.Browser
{
    class BrowserActivity
    {
        static string ActivityName = "Browser Activity";

        public static AndroidList FlowList
        {
            get
            {
                string id = "project_flows";
                string name = "Flow List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidList AssayList
        {
            get
            {
                string id = "project_assays";
                string name = "Assay List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidButton NewAssay
        {
            get
            {
                string id = "new_assay_button";
                string name = "New Assay";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton ShareAssay
        {
            get
            {
                string id = "assay_share";
                string name = "Share Assay";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton NewFlow
        {
            get
            {
                string id = "new_flow";
                string name = "New Flow";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton DeleteAssay
        {
            get
            {
                string id = "assay_delete";
                string name = "Delete Assay";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
