namespace ViewModel
{
    using Domain.Extensions;
    using Domain;
    using Zebble.Mvvm;
    using System.Threading.Tasks;
    using UI.Utils;

    class PopularShoesPage : FullScreen
    {
        readonly IShoeService ShoeService;

        public readonly WaitingAwareBindable IsBusy = new(false);
        public readonly CollectionViewModel<ShoeList.Item> Items = new();

        public PopularShoesPage()
        {
            ShoeService = new FirebaseShoeService();
        }

        protected override async Task NavigationStartedAsync()
        {
            using (await IsBusy.SetAsync(true))
            {
                var shoes = await ShoeService.GetPopularShoes();

                shoes.ForEach(Items.Add);
            }

            await base.NavigationStartedAsync();
        }
    }
}
