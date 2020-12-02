namespace Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    class FirebaseShoeService : IShoeService
    {
        public Task<IList<Shoe>> GetPopularShoes() => FirebaseShoeApis.GetPopularShoes();

        public Task<IList<Shoe>> GetLatestShoes() => FirebaseShoeApis.GetLatestShoes();
    }

    static class FirebaseShoeApis
    {
        public static async Task<IList<Shoe>> GetPopularShoes()
        {
            return new[]
            {
                new Shoe { Brand = "Adidas" },
                new Shoe { Brand = "Nike" },
                new Shoe { Brand = "Puma" }
            };
        }

        public static async Task<IList<Shoe>> GetLatestShoes()
        {
            return new[]
            {
                new Shoe { Brand = "Skechers" },
                new Shoe { Brand = "Givova" },
                new Shoe { Brand = "Humanic" }
            };
        }
    }
}
