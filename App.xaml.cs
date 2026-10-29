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
            //return new Window(new AppShell());
            //return new Window(new FontsWorkout());
            //return new Window(new Calculator());
            return new Window(new SignInPage());
        }
    }
}