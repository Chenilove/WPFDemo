using XWSDGCat.Common;
using XWSDGCat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Xml.Linq;
using XWSDGCat.View;
using System.Threading;

namespace XWSDGCat.ViewModel
{
    class LoginViewModel: NotifyBase
    {
        public LoginModel loginModel { get; set; }

        public CommandBase CloseWindowCommand { get; set; }
        public CommandBase LoginCommand { get; set; }

        private LoginView _loginView;
        private string _errorMsg;

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { _errorMsg = value; this.DoNotify(); }
        }

        private Visibility _showLoading = Visibility.Hidden;

        public Visibility ShowLoading
        {
            get { return _showLoading; }
            set { _showLoading = value; this.DoNotify(); }
        }

        private bool _isLoading = false;

        public bool IsLoading
        {
            get { return _isLoading; }
            set {
                _isLoading = value;
                Application.Current.Dispatcher.Invoke(new Action(() => {
                    _loginView.LoginButton.IsEnabled = !_isLoading;
                    if (_isLoading)
                    {
                        ShowLoading = Visibility.Visible;
                        _loginView.LoginButton.Content = "登录中......";
                    }
                    else
                    {
                        ShowLoading = Visibility.Hidden;
                        _loginView.LoginButton.Content = "登录";
                    }
                }));
            }
        }


        public LoginViewModel(LoginView loginView)
        {
            _loginView = loginView;

            loginModel = new LoginModel();
            loginModel.Username = "Javen";
            loginModel.Password = "";

            CloseWindowCommand = new CommandBase();
            CloseWindowCommand.DoExecute = new Action<object>((o) =>
            {
                (o as Window).Close();
            });
            CloseWindowCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });

            LoginCommand = new CommandBase();
            LoginCommand.DoExecute = new Action<object>(DoLogin);
            LoginCommand.DoCanExecute = new Func<object, bool>((o) => { return !IsLoading; });
        }

        public void DoLogin(object o)
        {
            IsLoading = true;
            ErrorMsg = string.Empty;
            
            Console.WriteLine(loginModel.Password);
            Thread thread = new Thread(() => { 
                Thread.Sleep(3000);
                if (loginModel.Username == string.Empty)
                {
                    ErrorMsg = "用户名不能为空";
                }
                if (loginModel.Password == string.Empty)
                {
                    ErrorMsg = "密码不能为空";
                }
                IsLoading = false;
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    (o as Window).DialogResult = true;
                }));
            });
            thread.Start();
            
            
        }
    }
}
