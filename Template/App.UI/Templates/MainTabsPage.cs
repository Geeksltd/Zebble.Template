namespace UI.Templates
{
    using System;
    using System.Threading.Tasks;
    using Zebble;

    class MainTabsPage : NavBarTabsPage<Modules.MainTabs>
    {
        public override async Task OnInitializing()
        {
            await base.OnInitializing();
            BodyScroller.Background(Colors.White);
            await WhenShown(() => new MainTabsMenuLauncher().Setup());
        }

        protected override View CreateBackButton() => new IconButton { CssClass = "navbar-button back" };

        protected override View CreateMenuIcon() => new ImageView { CssClass = "menu-icon" };

        protected override Task OnMenuTapped() => MainTabsMenuLauncher.Current.Show();
    }
}