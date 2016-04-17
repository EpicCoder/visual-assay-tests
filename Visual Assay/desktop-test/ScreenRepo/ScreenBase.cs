using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace desktop_test.ScreenRepo
{
    public abstract class ScreenBase
    {

        protected static T GetByAutomationId<T>(string id) where T : IUIItem
        {
            //            try
            //            {
            //                return _window.Get<T>(SearchCriteria.ByAutomationId(id));
            //            }
            //            catch (Exception ex)
            //            {
            //                throw;
            //            }
            return ApplicationUnderTest.Instance.MainWindow.Get<T>(SearchCriteria.ByAutomationId(id));
        }
    }
}
