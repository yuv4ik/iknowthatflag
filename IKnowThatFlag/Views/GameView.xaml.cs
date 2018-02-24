using Xamarin.Forms;

namespace IKnowThatFlag.Views
{
    public partial class GameView : ContentPage
    {
        public GameView()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
