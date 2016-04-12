using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

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
    }
}
