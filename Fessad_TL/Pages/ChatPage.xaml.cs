using System.Security;
using System.Windows;

namespace Fessad_TL
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<ChatListViewModel>
    {
        public ChatPage()
        {
            InitializeComponent();
        }

        private void ChatListControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
