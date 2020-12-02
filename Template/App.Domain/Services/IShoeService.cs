namespace Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    interface IShoeService
    {
        Task<IList<Shoe>> GetPopularShoes();
        Task<IList<Shoe>> GetLatestShoes();
    }
}
