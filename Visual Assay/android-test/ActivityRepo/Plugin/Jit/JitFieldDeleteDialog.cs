﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Plugin.Jit
{
    class JitFieldDeleteDialog
    {
        static string ActivityName = "Jit Field Delete Dialog";

        public static AndroidButton Cancel
        {
            get
            {
                string id = "button2";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Delete
        {
            get
            {
                string id = "button1";
                string name = "Delete";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
