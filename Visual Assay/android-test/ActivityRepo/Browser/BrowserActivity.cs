using System;
using android_test.ActivityElement;
using android_test.ActivityRepo.Flow;
using NUnit.Framework;

namespace android_test.ActivityRepo.Browser
{
    class BrowserActivity
    {
        static string ActivityName = "Browser Activity";

        public static AndroidList FlowList
        {
            get
            {
                string id = "project_flows";
                string name = "Flow List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidList AssayList
        {
            get
            {
                string id = "project_assays";
                string name = "Assay List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidButton NewAssay
        {
            get
            {
                string id = "new_assay_button";
                string name = "New Assay";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton ShareAssay
        {
            get
            {
                string id = "assay_share";
                string name = "Share Assay";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton NewFlow
        {
            get
            {
                string id = "new_flow";
                string name = "New Flow";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton DeleteAssay
        {
            get
            {
                string id = "assay_delete";
                string name = "Delete Assay";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static void CreateAssay(string assayName)
        {
            NewAssay.Tap();
            AssayCreateDialog.Name.EnterText(assayName);
            AssayCreateDialog.Create.Tap();
        }

        public static void CreateFlow(string flowName)
        {
            NewFlow.Tap();
            FlowTypeDialog.SelectFlowPlan();
            FlowCreateDialog.FlowName.EnterText(flowName);
            FlowCreateDialog.Create.Tap();
        }

        public static void VerifyFlowNotExist(string flowName)
        {
            try
            {
                Assert.True(FlowList.GetInternalElement().FindElementsByName(flowName).Count == 0,
                    String.Format("Flow with name: {0} still exist", flowName));
                ConsoleMessage.Pass(String.Format("{0}. Verify, flow with name: {1} not exist",
                    ActivityName, flowName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't verify. Flow with name: {1}  exist",
                    ActivityName, flowName), ex);
                throw;
            }
        }

        public static void VerifyAssayNotExit(string assayName)
        {
            try
            {
                if (Appium.Instance.Driver.FindElementsById("project_assays").Count > 0)
                {
                    Assert.True(AssayList.GetInternalElement().FindElementsByName(assayName).Count == 0,
                        String.Format("Assay with name: {0} still exist", assayName));
                }
                ConsoleMessage.Pass(String.Format("{0}. Verify, Assay with name: {1} not exist",
                    ActivityName, assayName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't verify. Assay with name: {1} exist",
                    ActivityName, assayName), ex);
                throw;
            }
        }

        public static void DeleteAllFlows()
        {
            try
            {
                var flowList = FlowList.GetInternalElement().FindElementsById("browser_element_name");
                while (flowList.Count > 0)
                {
                    string flowName = flowList[0].Text;
                    flowList[0].Click();
                    ConsoleMessage.Pass(String.Format("{0}. Click on flow with name: {1}",
                        ActivityName, flowName));
                    FlowActivity.DeleteFlow.Tap();
                    FlowDeleteDialog.Delete.Tap();
                    flowList = FlowList.GetInternalElement().FindElementsById("browser_element_name");
                }
                ConsoleMessage.Pass(String.Format("{0}. Delete all flow in current assay",
                    ActivityName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't delete all flow in current assay",
                    ActivityName), ex);
                throw;
            }
        }
    }
}
