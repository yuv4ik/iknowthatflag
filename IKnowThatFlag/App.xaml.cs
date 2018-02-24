using Autofac;
using IKnowThatFlag.Services;
using IKnowThatFlag.Views;
using Xamarin.Forms;

namespace IKnowThatFlag
{
    public partial class App : Application
    {
        public DependencyResolver DependencyResolver { get; }

        public App(Module platformIocModule)
        {
            InitializeComponent();

            DependencyResolver = new DependencyResolver(platformIocModule, new IocModule());

            MainPage = new WelcomeView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
