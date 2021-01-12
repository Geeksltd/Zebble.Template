namespace ViewModel
{
    using System.Linq;
    using Zebble;
    using Zebble.Mvvm;
    using Olive;

    class ShoesPage : FullScreen
    {
        public readonly CollectionViewModel<Item> Items = new CollectionViewModel<Item>();

        protected override void NavigationStarted()
        {
            var shoes = Enumerable.Range(1, 100).Select(v => new Domain.Shoe { Brand = "Shoe " + v }).ToArray();
            Items.Add(shoes);
        }

        public class Item : ViewModel<Domain.Shoe>
        {
            public Bindable<string> ImageUrl => Source.Get(x => x.ImageUrl);
            public Bindable<string> Brand => Source.Get(x => x.Brand);

            public void Tap()
            {
                Forward<ShoePage>(x => x.Source(Source));
            }
        }
    }
}