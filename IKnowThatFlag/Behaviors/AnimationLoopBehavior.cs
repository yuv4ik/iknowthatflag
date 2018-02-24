using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IKnowThatFlag.Behaviors
{
    public abstract class AnimationLoopBehavior<T> : Behavior<T> where T : BindableObject
    {
        CancellationTokenSource tknSrc = new CancellationTokenSource();

        protected override void OnAttachedTo(T bindable)
        {
            StartAnimation(bindable);
        }

        protected override void OnDetachingFrom(T bindable)
        {
            tknSrc.Cancel();
        }

        protected abstract Task Animate(T element);

        async Task StartAnimation(T element)
        {
            while (!tknSrc.IsCancellationRequested)
            {
                await Animate(element);
            } 
        }
    }
}
