namespace ViewModel
{
    using Domain;
    using Domain.Extensions;
    using System.Threading.Tasks;
    using Zebble;
    using Zebble.Mvvm;

    class ShoesPage : FullScreen
    {
        readonly IShoeService ShoeService;

        public readonly CollectionViewModel<Item> Items = new CollectionViewModel<Item>();

        public ShoesPage() => ShoeService = new FirebaseShoeService();

        protected override async Task NavigationStartedAsync()
        {
            Items.Clear();
            (await ShoeService.GetShoes()).ForEach(Items.Add);

            await base.NavigationStartedAsync();
        }

        public class Item : ViewModel<Domain.Shoe>
        {
            public Bindable<string> ImageUrl => Source.Get(x => x.ImageUrl);
            public Bindable<string> Brand => Source.Get(x => x.Brand);

            public void Tap()
            {
                The<ShoePage>().Source.Set(Source);
                Forward<ShoePage>();
            }
        }
    }
}