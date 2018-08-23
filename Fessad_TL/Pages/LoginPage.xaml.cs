

using System.Security;
using System.Windows;
using Fessad_TL;

namespace Fessad_TL
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public SecureString Password => passwordBox.SecurePassword;
    }
}
