namespace Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    interface IShoeService
    {
        Task<IList<Shoe>> GetShoes();
    }
}
