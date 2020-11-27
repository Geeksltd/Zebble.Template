using System;
using Zebble;
using Zebble.Mvvm;

namespace ViewModel
{
    class ShoePage : FullScreen
    {
        public readonly Bindable<Domain.Shoe> Source = new Bindable<Domain.Shoe>();
        public Bindable<string> Name => Source.Get(x => x.Name);
    }
}
