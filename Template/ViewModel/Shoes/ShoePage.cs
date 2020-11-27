using System;
using Zebble;
using Zebble.Mvvm;

namespace ViewModel
{
    class ShoePage : FullScreen<Domain.Shoe>
    {
        public Bindable<string> Name => Source.Get(x => x.Name);
    }
}
