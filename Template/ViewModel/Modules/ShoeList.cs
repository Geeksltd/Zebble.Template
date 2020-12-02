namespace ViewModel
{
    using Domain;
    using Zebble;
    using Zebble.Mvvm;

    class ShoeList : ViewModel
    {
        public CollectionViewModel<Item> Items;

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
