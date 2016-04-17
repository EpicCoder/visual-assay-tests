using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;

namespace desktop_test.DesktopElement
{
    class TextBoxWrapper
    {
        private TextBox _textBox;
        private string _screenName;
        private string _elementName;
        public TextBoxWrapper(IUIItem item, string screenName)
        {
            _textBox = (TextBox)item;
            _screenName = screenName;
            _elementName = "No element name";
        }

        public TextBoxWrapper(IUIItem item, string screenName, string elementName)
        {
            _textBox = (TextBox)item;
            _screenName = screenName;
            _elementName = elementName;
        }

        public void EnterText(string text)
        {
            Console.WriteLine("{0}. Enter text: {1} to text box: {2}", _screenName, text, _elementName);
            _textBox.BulkText = text;
        }
    }
}
