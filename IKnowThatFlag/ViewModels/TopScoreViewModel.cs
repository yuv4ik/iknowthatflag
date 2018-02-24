using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using IKnowThatFlag.Models;
using IKnowThatFlag.Repositories;
using IKnowThatFlag.Services;
using Xamarin.Forms;

namespace IKnowThatFlag.ViewModels
{
    public class TopScoreViewModel : BaseViewModel
    {
        public List<TopScoreModel> TopScores { get; private set; }

        public ICommand GoBackCmd { get; }

        TopScoreRepository topScoreRepository { get; }

        public TopScoreViewModel(
            TopScoreRepository topScoreRepository,
            INavigationService navigation) : base(navigation)
        {
            this.topScoreRepository = topScoreRepository;
            GoBackCmd = new Command(async () => await Navigation.PopModalAsync());
        }

        public async override Task InitializeAsync(object navigationData) =>
            TopScores = await topScoreRepository.GetLast10TopScores();
    }
}
