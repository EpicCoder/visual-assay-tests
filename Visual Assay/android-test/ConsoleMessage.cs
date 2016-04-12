using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace android_test
{
    class ConsoleMessage
    {
        public static void Pass(string text)
        {
            Console.WriteLine(text + "Status: Pass");
        }

        public static void Fail(string text, Exception ex)
        {
            Console.WriteLine(text + "Status: Fail");
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}
