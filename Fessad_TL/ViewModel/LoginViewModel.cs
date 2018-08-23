using System.Threading.Tasks; 
using System.Windows.Input;


namespace Fessad_TL
{
    public class LoginViewModel : BaseViewModel
    {
        #region Public properties

        public string Email { get; set; }

        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands
        /// <summary>
        /// Command to show app menu
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion  

        #region Constructor

        /// <summary>
        /// Defult Constructor
        /// </summary>
        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (page) => await Login(page));                         
        }

        #endregion

        public async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                var email = Email;
                var pass = (parameter as IHavePassword).Password.Unsecure() ?? "No password provided";
            });
        }
    }
}
