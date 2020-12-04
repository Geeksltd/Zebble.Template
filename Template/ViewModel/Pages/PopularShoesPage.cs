namespace ViewModel
{
    using Domain;
    using Zebble.Mvvm;
    using System.Threading.Tasks;
    using UI.Utils;
    using Domain.Extensions;
    using Zebble;

    class PopularShoesPage : FullScreen
    {
        readonly IShoeService ShoeService;

        public readonly WaitingAwareBindable IsBusy = new(false);
        public readonly CollectionViewModel<Item> Items = new();

        public PopularShoesPage()
        {
            ShoeService = new FirebaseShoeService();
        }

        protected override async Task NavigationStartedAsync()
        {
            using (await IsBusy.SetAsync(true))
            {
                Items.Clear();
                (await ShoeService.GetPopularShoes()).ForEach(Items.Add);
            }

            await base.NavigationStartedAsync();
        }

        public class Item : ViewModel<Shoe>
        {
            public Bindable<string> ImageUrl => Source.Get(x => x.ImageUrl);
            public Bindable<string> Brand => Source.Get(x => x.Brand);

            public void Tap()
            {
                The<ShoeDetailsPage>().Source.Set(Source);
                Forward<ShoeDetailsPage>();
            }
        }
    }
}
