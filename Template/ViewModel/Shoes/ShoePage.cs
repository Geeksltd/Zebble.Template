namespace ViewModel
{
    using Zebble;
    using Zebble.Mvvm;

    class ShoePage : FullScreen<Domain.Entities.Shoe>
    {
        public Bindable<string> Name => Source.Get(x => x.Brand);

        // Note: You can have nested view models:
        public readonly ShoeHeader Header = new ShoeHeader();

        public ShoePage()
        {
            Header.Source.Bind(Source, x => x);
        }
    }

    class ShoeHeader : ViewModel<Domain.Entities.Shoe>
    {
        public Bindable<string> Image => Source.Get(x => x.ImageUrl);
    }
}
