using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo
{
    class SearchActivity
    {
        static string ActivityName = "Search Activity";

        public static AndroidList SearchResultList
        {
            get
            {
                string id = "search_results";
                string name = "Search Result List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidButton Search
        {
            get
            {
                string id = "search_button";
                string name = "Search";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText SearchText
        {
            get
            {
                string id = "search_src_text";
                string name = "Search Textbox";
                return new AndroidEditText(id, name, ActivityName);
            }
        }
    }
}
