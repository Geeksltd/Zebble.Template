using System;
using System.Linq;
using Zebble;
using Zebble.Mvvm;

namespace ViewModel
{
    class ShoesPage : FullScreen
    {
        public Bindable<DateTime> Date = new Bindable<DateTime>(LocalTime.Today);
        public Bindable<string> Tomorrow => Date.Get(x => x.AddDays(1).ToString("dd MMM yyyy"));

        public void SayHi()
        {
            Dialog.Alert("Hi");
        }

        public readonly CollectionViewModel<Item> Items = new CollectionViewModel<Item>();

        protected override void NavigationStarted()
        {
            var shoes = Enumerable.Range(1, 100).Select(v => new Domain.Shoe { Brand = "Shoe " + v }).ToArray();
            Items.Add(shoes);
        }

        public class Item : ViewModel<Domain.Shoe>
        {
            public Bindable<string> Brand => Source.Get(x => x.Brand);
            public Bindable<string> ImageUrl => Source.Get(x => x.ImageUrl);

            public void Tap()
            {
                The<ShoePage>().Source.Set(Source);
                Forward<ShoePage>();
            }
        }
    }
}