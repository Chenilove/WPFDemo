using XWSDGCat.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWSDGCat.Model
{
    public class LoginModel : NotifyBase
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set {
                _username = value;
                this.DoNotify();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { 
                _password = value;
                this.DoNotify();
            }
        }
    }
}
