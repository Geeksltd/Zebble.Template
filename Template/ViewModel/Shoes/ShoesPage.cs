﻿namespace ViewModel
{
    using Domain;
    using Domain.Extensions;
    using System.Linq;
    using System.Threading.Tasks;
    using Zebble;
    using Zebble.Mvvm;

    class ShoesPage : FullScreen
    {
        public readonly CollectionViewModel<Item> Items = new CollectionViewModel<Item>();

        protected override async Task NavigationStartedAsync()
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
                The<ShoePage>().Source.Set(Source);
                Forward<ShoePage>();
            }
        }
    }
}