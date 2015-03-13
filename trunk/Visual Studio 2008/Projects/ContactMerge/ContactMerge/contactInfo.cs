using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactMerge
{
    public class contactInfo
    {
        private string name;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        private string email;
        public string Email
        {
            set { email = value; }
            get { return email; }
        }

        private string facebook;
        public string Facebook
        {
            set { facebook = value; }
            get { return facebook; }
        }

        private string twitter;
        public string Twitter
        {
            set { twitter = value; }
            get { return twitter; }
        }
    }
}
