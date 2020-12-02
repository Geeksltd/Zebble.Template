namespace ViewModel
{
    using Domain.Extensions;
    using Domain;
    using Zebble.Mvvm;

    class LatestShoesTab : ViewModel
    {
        readonly IShoeService ShoeService;

        public readonly CollectionViewModel<ShoeList.Item> Items = new();

        public LatestShoesTab()
        {
            ShoeService = new FirebaseShoeService();

            ShoeService.GetLatestShoes().ContinueWith(x => x.Result.ForEach(Items.Add));
        }
    }
}
