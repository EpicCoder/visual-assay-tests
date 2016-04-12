using System;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace android_test
{
    public class Appium
    {
        private static Appium _instance;

        public AndroidDriver<AndroidElement> Driver;

        public static Appium Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                return _instance = new Appium();
            }
        }

        private Appium()
        {            
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("app", Settings.Instance.AppPath);
            capabilities.SetCapability("deviceName", "Google Nexus");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("autoLaunch", "false");
            Driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
        }
    }
}
