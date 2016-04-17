using System;
using System.Collections.ObjectModel;
using android_test.ActivityElement;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

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

        public static void CheckLibraryToShare(string libraryName)
        {
            try
            {
                ReadOnlyCollection<AppiumWebElement> libList =
                    LibraryList.GetInternalElement().FindElementsById("library_row_layout");
                foreach (var element in libList)
                {
                    if (element.FindElementById("library_title").Text == libraryName)
                    {
                        element.Click();
                        element.FindElementById("chkLibrary").Click();
                        CommonOperation.Delay(1);
                        Assert.True(Boolean.Parse(element.FindElementById("chkLibrary").GetAttribute("checked")),
                            "Library " + libraryName + " checkbox status unchecked after click on checkbox");
                        ConsoleMessage.Pass(String.Format("{0}. Checked library for share with name: {1}", ActivityName, libraryName));
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't checked library for share with name: {1}", ActivityName, libraryName), ex);
                throw;
            }
        }

        public static void VerifyCantShareLibrary(string libraryName)
        {
            try
            {
                ReadOnlyCollection<AppiumWebElement> libList =
                    LibraryList.GetInternalElement().FindElementsById("library_row_layout");
                foreach (var element in libList)
                {
                    if (element.FindElementById("library_title").Text == libraryName)
                    {
                        element.Click();
                        element.FindElementById("chkLibrary").Click();
                        CommonOperation.Delay(1);
                        Assert.False(Boolean.Parse(element.FindElementById("chkLibrary").GetAttribute("checked")),
                            "Can check " + libraryName + " checkbox without share permission");
                        ConsoleMessage.Pass(String.Format("{0}. Can't Checked library for share with name: {1} without permission", ActivityName, libraryName));
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can checked library for share with name: {1} without permission", ActivityName, libraryName), ex);
                throw;
            }
        }

        public static void DeleteAllLibs()
        {
            try
            {
                string standard = "Standard";
                ReadOnlyCollection<AppiumWebElement> libList =
                    LibraryList.GetInternalElement().FindElementsById("library_row_layout");
                int shift = 0;
                while (libList.Count > 1)
                {
                    string libName = libList[shift].FindElementById("library_title").Text;
                    if (libName == standard)
                    {
                        shift++;
                    }
                    ConsoleMessage.Pass(String.Format("{0}. Select library with name: {1}", ActivityName, libName));
                    libList[shift].Click();
                    DeleteLibrary.Tap();
                    LibraryDeleteDialog.Delete.Tap();
                    libList =
                        LibraryList.GetInternalElement().FindElementsById("library_row_layout");
                }
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't delete all libraries: {1}", ActivityName), ex);
                throw;
            }
        }

        public static void VerifyLibraryNotExist(string libraryName)
        {
            try
            {
                Assert.True(LibraryList.GetInternalElement().FindElementsByName(libraryName).Count == 0, "Library with name: " + libraryName + " exist");
                ConsoleMessage.Pass(String.Format("{0}. Verify, library with name: {1} not exist", ActivityName, libraryName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Verify fail. Library with name: {1} still exist", ActivityName, libraryName), ex);
                throw;
            }
        }


        public static void SelectAndShareLibrary(string baseLibrary, string shareName)
        {
            LibraryList.FindAndTap(baseLibrary);
            ShareLibrary.Tap();
            CheckLibraryToShare(baseLibrary);
            ShareLibraryName.EnterText(shareName);
            Next.Tap();
        }

        public static void CreateLibrary(string libName)
        {
            AddLibrary.Tap();
            LibraryCreateDialog.LibraryName.EnterText(libName);
            LibraryCreateDialog.Create.Tap();
        }
    }
}
