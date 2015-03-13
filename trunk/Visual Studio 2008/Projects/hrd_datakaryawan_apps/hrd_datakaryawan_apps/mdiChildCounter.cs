using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps
{
    public class mdiChildCounter
    {        
        private int mDIChildSum;

        public int MDIChildInc
        {
            set { mDIChildSum =+ 1; }
        }

        public int MDIChildDec
        {
            set { mDIChildSum = -1; }
        }

        public int getMDIChildSum
        {
            get { return mDIChildSum; }
        }
    }
}
