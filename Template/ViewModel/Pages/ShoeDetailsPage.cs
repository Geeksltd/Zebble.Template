namespace ViewModel
{
    using Zebble;
    using Zebble.Mvvm;
    using Domain;

    class ShoeDetailsPage : FullScreen<Shoe>
    {
        public Bindable<string> Brand => Source.Get(x => x.Brand);

        public readonly ShoeDetailsHeader Header = new();

        public ShoeDetailsPage()
        {
            Header.Source.Bind(Source, x => x);
        }
    }

    class ShoeDetailsHeader : ViewModel<Shoe>
    {
        public Bindable<string> ImageUrl => Source.Get(x => x.ImageUrl);
    }
}
