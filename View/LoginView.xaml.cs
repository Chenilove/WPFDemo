using XWSDGCat.Model;
using XWSDGCat.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace XWSDGCat.View
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Window
    {

        public LoginView()
        {
            InitializeComponent();

            this.DataContext = new LoginViewModel(this);
        }

        private void Button_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
