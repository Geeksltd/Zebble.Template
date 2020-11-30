using System.Threading.Tasks;
using Zebble;
using Zebble.Mvvm;

namespace ViewModel
{
    class ShoesPage : FullScreen
    {
        public readonly CollectionViewModel<Item> Items = new CollectionViewModel<Item>();

        protected override void NavigationStarted()
        {
            Items.Add(new Domain.Shoe { Brand = "Nike" });
            Items.Add(new Domain.Shoe { Brand = "Adidas" });
        }
    }

    class Item : ViewModel<Domain.Shoe>
    {
        public Bindable<string> Brand => Source.Get(x => x.Brand);

        public void Tap()
        {
            The<ShoePage>().Source.Set(Source);
            Forward<ShoePage>();
        }
    }
}
