namespace ViewModel
{
    using Domain.Extensions;
    using Domain;
    using Zebble.Mvvm;

    class PopularShoesTab : ViewModel
    {
        readonly IShoeService ShoeService;

        public readonly CollectionViewModel<ShoeList.Item> Items = new();

        public PopularShoesTab()
        {
            ShoeService = new FirebaseShoeService();

            ShoeService.GetPopularShoes().ContinueWith(x => x.Result.ForEach(Items.Add));
        }
    }
}
