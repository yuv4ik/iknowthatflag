using System.ComponentModel;
using System.Threading.Tasks;
using IKnowThatFlag.Services;

namespace IKnowThatFlag.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public INavigationService Navigation { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel(INavigationService navigation)
        {
            Navigation = navigation;
        }

        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);
    }
}