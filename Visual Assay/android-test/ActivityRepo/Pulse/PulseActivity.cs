using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;
using android_test.ActivityRepo.Flow;
using NUnit.Framework;

namespace android_test.ActivityRepo.Pulse
{
    class PulseActivity
    {
        static string ActivityName = "Pulse Activity";

        public static AndroidList ElementList
        {
            get
            {
                string id = "project_assays_list";
                string name = "Main List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidList HeaderList
        {
            get
            {
                string id = "project_assays_header";
                string name = "Header List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidButton Export
        {
            get
            {
                string name = "Export";
                return new AndroidButton(name, ActivityName);
            }
        }

        public static AndroidButton CustomizeView
        {
            get
            {
                string name = "Customize View";
                return new AndroidButton(name, ActivityName);
            }
        }

        public static void VerifyListNotEmpty()
        {
            try
            {
                int currentSize =
                    ElementList.GetInternalElement().FindElementsByClassName("android.widget.TableLayout").Count;
                Assert.Greater(currentSize, 0, "Current list item count equal 0");
                ConsoleMessage.Pass(String.Format("{0}. Verify {1} not empty",
                    ActivityName, ElementList.ElementName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. {1} is empty",
                    ActivityName, "Pulse list"), ex);
                throw;
            }
        }

        public static void MoveToFlow()
        {
            try
            {
                var flowElement = ElementList.GetInternalElement()
                    .FindElementByClassName("android.widget.TableRow")
                    .FindElementsByClassName("android.widget.TextView")[2];
                string expectedFlowName = flowElement.Text;
                flowElement.Click();
                CommonOperation.Delay(1);
                string currentName = FlowActivity.FlowName.GetInternalElement().Text;
                Assert.AreEqual(expectedFlowName, currentName,
                    "Current flow name: " + currentName + " not equal to expected: " + expectedFlowName);
                ConsoleMessage.Pass(String.Format("{0}. Verify, move to flow function. Click on first flow in list: {1}",
                    ActivityName, expectedFlowName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't verify move to flow function",
                    ActivityName), ex);
                throw;
            }
        }
    }
}
