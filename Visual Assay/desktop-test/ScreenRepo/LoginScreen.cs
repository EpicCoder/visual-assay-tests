using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using desktop_test.DesktopElement;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace desktop_test.ScreenRepo
{
    class LoginScreen : ScreenBase
    {
        static string ScreenName = "Login Screen";

        public static ButtonWrapper Login
        {
            get
            {
                return new ButtonWrapper(GetByAutomationId<Button>("LoginButton"), ScreenName);
            }
        }

        public static TextBoxWrapper UserName
        {
            get
            {
                var elementName = "User Name";
                return new TextBoxWrapper(GetByAutomationId<TextBox>("UsernameBox"), ScreenName, elementName);
            }
        }

        public static TextBoxWrapper UserPassword
        {
            get
            {
                var elementName = "User Name";
                return new TextBoxWrapper(GetByAutomationId<TextBox>("PasswordBox"), ScreenName, elementName);
            }
        }

        public static CheckBoxWrapper RememberMe
        {
            get
            {
                var elementName = "Remember me";
                return new CheckBoxWrapper(GetByAutomationId<CheckBox>("SavePasswordCheck"), ScreenName, elementName);
            }
        }

        public static void VerifyLogin(int timeout)
        {
            double timeOutInMillSeconds = TimeSpan.FromSeconds(timeout).TotalMilliseconds;
            Stopwatch sw = new Stopwatch();
            try
            {
                sw.Start();
                while (sw.ElapsedMilliseconds < timeOutInMillSeconds)
                {
                    if (ApplicationUnderTest.Instance.MainWindow.Exists(
                        SearchCriteria.ByAutomationId("OpenNewAssayDialogButton")))
                    {
                        sw.Stop();
                        Console.WriteLine(String.Format("{0}. Login success. Login time: {1}",
                            ScreenName, TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds).TotalSeconds));
                        return;
                    }
                }
                Assert.Fail("{0}. Login timeout: {1} sec.", ScreenName, timeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("{0}. Can't Login",
                    ScreenName), ex);
                throw;
            }
        }
    }
}
