using System;
using System.Threading.Tasks;
using Zebble;

namespace UI.Templates
{
    class NavBarTabs : NavBar
    {
        static NavBarTabs() => Nav.NavigationAnimationStarted.FullEvent += HandleNavigationAnimationStarted;

        static void HandleNavigationAnimationStarted(NavigationEventArgs args)
        {
            if (args.From is PopUp || args.To is PopUp) return;

            var fromTabs = args.From is NavBarTabs;
            var toTabs = args.To is NavBarTabs;

            if (fromTabs && toTabs) Tabs.Appear();
            if (fromTabs && !toTabs) Tabs.Disappear(animate: true);
            if (!fromTabs && toTabs) Tabs.Appear(animate: true);
            if (!fromTabs && !toTabs) Tabs.Disappear();
        }

        public override async Task OnPreRender()
        {
            await base.OnPreRender();
            await Tabs.Current.Attach();
            Height.BindTo(Root.Height, Tabs.Current.Height, (x, y) => x - y);
        }
    }
}