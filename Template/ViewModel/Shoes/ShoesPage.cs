using System;
using Zebble;
using Zebble.Mvvm;

namespace ViewModel
{
    class ShoesPage : FullScreen
    {
        public readonly Bindable<Item[]> Items = new Bindable<Item[]>();
    }

    public class Item : Zebble.Mvvm.ViewModel
    {
        readonly Bindable<Domain.Shoe> Source = new Bindable<Domain.Shoe>();
        public Bindable<string> Name => Source.Get(x => x.Name);

        public void Tap()
        {
            The<ShoePage>().Source.Set(Source);
            Forward<ShoePage>();
        }
    }
}
