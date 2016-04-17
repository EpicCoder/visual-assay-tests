using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;

namespace desktop_test.DesktopElement
{
    class CheckBoxWrapper
    {
        private CheckBox _checkBox;
        private string _screenName;
        private string _elementName;
        public CheckBoxWrapper(IUIItem item, string screenName)
        {
            _checkBox = (CheckBox)item;
            _screenName = screenName;
            _elementName = "No element name";
        }

        public CheckBoxWrapper(IUIItem item, string screenName, string elementName)
        {
            _checkBox = (CheckBox)item;
            _screenName = screenName;
            _elementName = elementName;
        }
    }
}
