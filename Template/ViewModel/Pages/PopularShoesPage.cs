namespace ViewModel
{
    using Domain.Extensions;
    using Domain;
    using Zebble.Mvvm;
    using System.Threading.Tasks;
    using Zebble;

    class PopularShoesPage : FullScreen
    {
        readonly IShoeService ShoeService;

        public readonly Bindable<bool> IsBusy = new(false);
        public readonly CollectionViewModel<ShoeList.Item> Items = new();

        public PopularShoesPage()
        {
            ShoeService = new FirebaseShoeService();
        }

        protected override async Task NavigationStartedAsync()
        {
            IsBusy.Set(true);

            var shoes = await ShoeService.GetPopularShoes();

            shoes.ForEach(Items.Add);

            IsBusy.Set(false);

            await base.NavigationStartedAsync();
        }
    }
}
