namespace Zebble
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    partial class NavigationBar
    {
        readonly Bindable<Guid> Visit = new Bindable<Guid>();
        Bindable<bool> CanGoBack => Visit.Get(x => Nav.Stack.Any());

        public NavigationBar()
        {
            Nav.NavigationAnimationStarted.Handle(OnNavigationAnimationStarted);
        }

        void OnNavigationAnimationStarted(NavigationEventArgs args)
        {
            if (args.From is PopUp || args.To is PopUp) return;

            if (args.To == Page)
            {
                Visit.Set(Guid.NewGuid());
                AllChildren.Do(c => c.Animate(Animation.DefaultDuration, b => b.Opacity(1)));
            }
            else if (args.From == Page)
            {
                AllChildren.Do(c => c.Animate(Animation.DefaultDuration.Multiply(1.5), b => b.Opacity(0)));
            }
        }

        Task OpenMenu()
        {
            return null;
        }
    }
}