using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUILearning.Models;
using MAUILearning.Services;
using MAUILearning.Views;
using Newtonsoft.Json;
using System.Windows.Input;

namespace MAUILearning.ViewModels
{
    public partial class LoginPageViewModel: BaseViewModel
    {
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _password;

        // ICommand property
        public ICommand LoginCommand { get; }

        readonly ILoginRepository loginRepository;
        // Constructor
        public LoginPageViewModel()
        {
            // Initialize the ICommand with the Login method
            loginRepository = new LoginService();
            LoginCommand = new RelayCommand(Login);
        }

        // The method to be executed when the command is triggered
        private async void Login()
        {
            if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password)) 
            {
                UserInfo userInfo = await loginRepository.Login(UserName, Password);
                if (userInfo != null)
                {
                    if (Preferences.ContainsKey(nameof(App.UserInfo)))
                    {
                        Preferences.Remove(nameof(App.UserInfo));
                    }

                    string userDetails = JsonConvert.SerializeObject(userInfo);
                    Preferences.Set(nameof(App.UserInfo), userDetails);

                    App.UserInfo = userInfo;
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }          
            }
        }
    }
}
