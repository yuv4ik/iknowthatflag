using System;
using System.Windows.Input;
using IKnowThatFlag.Services;
using Xamarin.Forms;

namespace IKnowThatFlag.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand GoBackCmd { get; }
        public ICommand OpenUrlCmd { get; }

        public AboutViewModel(INavigationService navigation) : base(navigation)
        {
            GoBackCmd = new Command(async () => await navigation.PopModalAsync());
            OpenUrlCmd = new Command(() => Device.OpenUri(new Uri("https://github.com/yuv4ik")));
        }
    }
}
