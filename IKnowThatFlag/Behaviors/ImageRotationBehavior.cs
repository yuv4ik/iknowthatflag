using System.Threading.Tasks;
using Xamarin.Forms;

namespace IKnowThatFlag.Behaviors
{
    public class ImageRotationBehavior : AnimationLoopBehavior<Image>
    {
        protected override async Task Animate(Image element)
        {
            await element.RotateTo(360, 15000, Easing.Linear);
            await element.RotateTo(0, 0); // reset to initial position
        }
    }
}
