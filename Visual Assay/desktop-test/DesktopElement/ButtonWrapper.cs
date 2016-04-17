using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;

namespace desktop_test.DesktopElement
{
    class ButtonWrapper
    {
        private Button _button;
        private string _screenName;
        public ButtonWrapper(IUIItem item, string screenName)
        {
            _button = (Button) item;
            _screenName = screenName;
        }

        public void Click()
        {
            Console.WriteLine("{0}. Click on button with name: {1}", _screenName, _button.Text);
            _button.Click();
        }
    }
}
