using System.Threading.Tasks;
using IKnowThatFlag.ViewModels;
using Xamarin.Forms;

namespace IKnowThatFlag.Services
{
    public interface INavigationService
    {
        Task PushAsync(Page page, bool animated = true);
        Task PopAsync(bool animated = true);

        Task PushModalAsync<TViewModel>(object parameter = null, bool animated = true) where TViewModel : BaseViewModel;
        Task PopModalAsync(bool animated = true);
    }
}
