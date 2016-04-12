using System;
using System.Diagnostics;
using android_test.ActivityElement;
using android_test.Entity;
using NUnit.Framework;

namespace android_test.ActivityRepo.Login
{
    class LoginActivity
    {
        static string ActivityName = "Login Activity";

        public static AndroidButton RegisterUser
        {
            get
            {
                string id = "login_user_register_new";
                string name = "Register User";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Login
        {
            get
            {
                string id = "login_confirm";
                string name = "Login";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText UserName
        {
            get
            {
                string id = "login_user_name";
                string name = "User Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidEditText UserPassword
        {
            get
            {
                string id = "login_user_password";
                string name = "User Password";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static void VerifyLogin(int timeout)
        {
            string expectedActivity = ".ProjectsBrowserActivity";
            double timeOutInMillSeconds = TimeSpan.FromSeconds(timeout).TotalMilliseconds;
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (sw.ElapsedMilliseconds < timeOutInMillSeconds)
                {
                    if (Appium.Instance.Driver.CurrentActivity == expectedActivity)
                    {
                        sw.Stop();
                        Console.WriteLine("Login time: {0} sec.", TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds).TotalSeconds);
                        return;
                    }
                }
                Assert.Fail("{0}. Login timeout: {1} sec.", ActivityName, timeout);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void LoginStep(User user, int timeout)
        {
            RegisterUser.Tap();
            UserName.EnterText(user.Name);
            UserPassword.EnterText(user.Password);
            Login.Tap();
            VerifyLogin(timeout);
        }
    }
}
