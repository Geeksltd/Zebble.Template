namespace ViewModel
{
    using Zebble.Mvvm;

    class MainTabs : ViewModel
    {
        public void TapHome() => Go<HomePage>();

        public void TapPopularShoes() => Go<PopularShoesPage>();

        public void TapLatestShoes() => Go<LatestShoesPage>();
    }
}
