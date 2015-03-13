using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hrd_datakaryawan_apps
{
    public interface iListener
    {
        /* init of 1 is for the txtGBUkuranPakaian,
         * init of 2 is for the txtGBInfoEmail,
         * init of 3 is for the txtGBInfoResign,
         * 
         * genIntNumb's value is used to describe the numbers of email addresses owned by the employee
         * Value of 0 for the genIntNumb's value used to describe zero value of the employee's email address number
         * or to describe that the method being called is not a method for the txtGBInfoEmail.
         */
        void Ok(object[] data, int genIntNumb, int init);
        void Ok(string[] data, int init);

        void setFlag(int wFlag);
    }
}
