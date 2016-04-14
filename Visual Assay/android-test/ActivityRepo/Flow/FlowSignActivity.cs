using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Flow
{
    class FlowSignActivity
    {
        static string ActivityName = "Flow Sign Activity";

        public static AndroidButton Ok
        {
            get
            {
                string id = "signature_ok";
                string name = "Ok";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton SignSignature
        {
            get
            {
                string id = "sign_button";
                string name = "Sign: Signature";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton SignWitness
        {
            get
            {
                string id = "sign_witness_button";
                string name = "Sign: Witness";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
