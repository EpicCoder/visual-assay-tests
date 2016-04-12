using android_test.ActivityElement;

namespace android_test.ActivityRepo.Library
{
    class LibraryActivity
    {
        static string ActivityName = "Library Activity";

        public static AndroidList LibraryList
        {
            get
            {
                string id = "libraries";
                string name = "Library List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidList ElementList
        {
            get
            {
                string id = "element_cart";
                string name = "Element List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidButton AddLibrary
        {
            get
            {
                string id = "library_add";
                string name = "Add Library";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton ShareLibrary
        {
            get
            {
                string id = "share_library";
                string name = "Share Library";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton AddElement
        {
            get
            {
                string id = "add_new_element";
                string name = "Add Element";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton DeleteLibrary
        {
            get
            {
                string id = "delete_library";
                string name = "Delete Library";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Permission
        {
            get
            {
                string id = "permissions_library";
                string name = "Permission";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText LibraryName
        {
            get
            {
                string id = "library_name";
                string name = "Library Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidEditText ShareLibraryName
        {
            get
            {
                string id = "shared_library_name";
                string name = "Share Library Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidList ShareElementList
        {
            get
            {
                string id = "library_share_elements";
                string name = "Share Element List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidButton Next
        {
            get
            {
                string id = "next";
                string name = "Next";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton CancelShare
        {
            get
            {
                string id = "cancelShare";
                string name = "Cancel Share";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
