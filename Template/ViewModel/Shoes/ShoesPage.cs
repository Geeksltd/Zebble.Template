namespace ViewModel
{
    using Zebble;
    using Zebble.Mvvm;
    using Domain.Entities;

    class ShoesPage : FullScreen
    {
        public readonly CollectionViewModel<Item> Items = new CollectionViewModel<Item>();

        protected override void NavigationStarted()
        {
            Items.Add(new Shoe { Brand = "Nike" });
            Items.Add(new Shoe { Brand = "Adidas" });
        }
    }

    class Item : ViewModel<Shoe>
    {
        public Bindable<string> Brand => Source.Get(x => x.Brand);

        public void Tap()
        {
            The<ShoePage>().Source.Set(Source);
            Forward<ShoePage>();
        }
    }
}
