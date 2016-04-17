using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;
using NUnit.Framework;

namespace android_test.ActivityRepo
{
    class ArchiveActivity
    {
        static string ActivityName = "Flow Archive Activity";

        public static AndroidList DeletedList
        {
            get
            {
                string id = "deletedList";
                string name = "Delete List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static void VerifyFlowInListAtPosition(int row, string flowName)
        {
            try
            {
                string currFlowName =
                    DeletedList.GetInternalElement().FindElementsById("deletedRow")[row].FindElementById("record_name")
                        .Text;
                Assert.AreEqual(flowName, currFlowName,
                    String.Format("Current flow name: {0} at position: {1} not equal to expected name: {2}",
                        currFlowName, row, flowName));
                ConsoleMessage.Pass(String.Format("{0}. Find flow name: {1} at position: {2}",
                    ActivityName, currFlowName, row));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't find flow name: {1} at position: {2}",
                    ActivityName, flowName, row), ex);
                throw;
            }
        }

        public static void RestoreAtPosition(int row)
        {
            try
            {
                DeletedList.GetInternalElement().FindElementsById("deletedRow")[row].FindElementById("restore_button")
                    .Click();
                ConsoleMessage.Pass(String.Format("{0}. Click restore button on #row: {1}",
                    ActivityName, row));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't click restore button on #row: {1}",
                    ActivityName, row), ex);
                throw;
            }
        }
    }
}
