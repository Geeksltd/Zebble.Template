using System;
using Zebble;
using Zebble.Mvvm;

namespace ViewModel
{
    class ShoePage : FullScreen<Domain.Shoe>
    {
        public Bindable<string> Name => Source.Get(x => x.Brand);

        // Note: You can have nested view models:
        public readonly ShoeHeader Header = new ShoeHeader();

        public ShoePage()
        {
            Header.Source.Bind(Source, x => x);
        }
    }

    class ShoeHeader : ViewModel<Domain.Shoe>
    {
        public Bindable<string> Image => Source.Get(x => x.ImageUrl);
    }
}
