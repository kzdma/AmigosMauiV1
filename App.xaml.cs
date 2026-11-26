using AmigosMauiV1.Views;

namespace AmigosMauiV1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var navPage = new NavigationPage(new SignInPage());
            return new Window(navPage);
        }
    }
}