namespace Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    class FirebaseShoeService : IShoeService
    {
        public Task<IList<Shoe>> GetShoes() => FirebaseShoeApis.GetShoes();
    }

    static class FirebaseShoeApis
    {
        public static async Task<IList<Shoe>> GetShoes()
        {
            return new[]
            {
                new Shoe {
                    Brand = "Nike",
                    ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?ixid=MXwxMjA3fDB8MHxzZWFyY2h8MXx8c2hvZXN8ZW58MHx8MHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                },
                new Shoe {
                    Brand = "Adidas",
                    ImageUrl = "https://images.unsplash.com/photo-1491553895911-0055eca6402d?ixid=MXwxMjA3fDB8MHxzZWFyY2h8Nnx8c2hvZXN8ZW58MHx8MHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                },
                new Shoe {
                    Brand = "Adidas",
                    ImageUrl = "https://images.unsplash.com/photo-1539185441755-769473a23570?ixid=MXwxMjA3fDB8MHxzZWFyY2h8MXx8c2hvZXMlMjBwdW1hfGVufDB8fDB8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                }
            };
        }
    }
}
