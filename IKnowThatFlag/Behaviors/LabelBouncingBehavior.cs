using System.Threading.Tasks;
using Xamarin.Forms;

namespace IKnowThatFlag.Behaviors
{
    public class LabelBouncingBehavior : AnimationLoopBehavior<Label>
    {
        protected override async Task Animate(Label element)
        {
            await element.RelScaleTo(0.1, 5000);
            await element.RelScaleTo(-0.1, 5000);
        }
    }
}
