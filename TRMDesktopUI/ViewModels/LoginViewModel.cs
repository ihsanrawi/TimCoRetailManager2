using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _UserName;
        private string _Password;
        // private IAPIHelper _apiHelper;

        //public LoginViewModel(IAPIHelper apiHelper)
        //{
        //    _apiHelper = apiHelper;
        //}

        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }


        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool CanLogIn
        {
            get
            {
                bool output = false;
                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }

                return output;
            }
        }
        public void Task LogIn()
        {
            Console.WriteLine("test");
        }
    }
}
