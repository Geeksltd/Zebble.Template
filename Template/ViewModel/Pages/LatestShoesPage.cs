namespace ViewModel
{
    using Domain.Extensions;
    using Domain;
    using Zebble.Mvvm;
    using System.Threading.Tasks;
    using UI.Utils;

    class LatestShoesPage : FullScreen
    {
        readonly IShoeService ShoeService;

        public readonly WaitingAwareBindable IsBusy = new(false);
        public readonly CollectionViewModel<ShoeList.Item> Items = new();

        public LatestShoesPage()
        {
            ShoeService = new FirebaseShoeService();
        }

        protected override async Task NavigationStartedAsync()
        {
            using (await IsBusy.SetAsync(true))
            {
                var shoes = await ShoeService.GetLatestShoes();

                shoes.ForEach(Items.Add);
            }

            await base.NavigationStartedAsync();
        }
    }
}
