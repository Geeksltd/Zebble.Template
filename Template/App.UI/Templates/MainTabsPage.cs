namespace UI.Templates
{
    using System.Threading.Tasks;
    using UI.Modules;
    using Zebble;

    class MainTabsPage : NavBarTabsPage<MainTabs>
    {
        public override async Task OnInitializing()
        {
            await base.OnInitializing();

            await WhenShown(() => new MainTabsMenuLauncher().Setup());
        }

        protected override View CreateBackButton() => new IconButton { CssClass = "navbar-button back" };

        protected override View CreateMenuIcon() => new ImageView { CssClass = "menu-icon" };

        protected override Task OnMenuTapped() => MainTabsMenuLauncher.Current.Show();
    }

    class MainTabsMenuLauncher : MainMenuLauncher<MainTabs> { }
}