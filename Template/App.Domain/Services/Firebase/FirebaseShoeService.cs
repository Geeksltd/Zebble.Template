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
                new Shoe {
                    ProductName = "Professional Sneakers with 100% Cotton",
                    Brand = "Nike",
                    ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?ixid=MXwxMjA3fDB8MHxzZWFyY2h8MXx8c2hvZXN8ZW58MHx8MHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                    Colors = new [] { "red", "blue", "yellow" },
                    Price = 139.99M,
                    RemainedQuantity = 10
                },
                new Shoe {
                    ProductName = "Running shoes with washable materials",
                    Brand = "Adidas",
                    ImageUrl = "https://images.unsplash.com/photo-1491553895911-0055eca6402d?ixid=MXwxMjA3fDB8MHxzZWFyY2h8Nnx8c2hvZXN8ZW58MHx8MHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                    Colors = new [] { "grey", "black" },
                    Price = 259.99M,
                    RemainedQuantity = 3
                },
                new Shoe {
                    ProductName = "Latest Sneakers built with latest technologies",
                    Brand = "Adidas",
                    ImageUrl = "https://images.unsplash.com/photo-1539185441755-769473a23570?ixid=MXwxMjA3fDB8MHxzZWFyY2h8MXx8c2hvZXMlMjBwdW1hfGVufDB8fDB8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                    Colors = new [] { "black", "white" },
                    Price = 139.99M,
                    RemainedQuantity = 10
                }
            };
        }

        public static async Task<IList<Shoe>> GetLatestShoes()
        {
            return new[]
            {
                new Shoe {
                    ProductName = "California Sneakers for Professionals",
                    Brand = "Adidas",
                    ImageUrl = "https://images.unsplash.com/photo-1512374382149-233c42b6a83b?ixid=MXwxMjA3fDB8MHxzZWFyY2h8MjV8fHNob2VzJTIwcHVtYXxlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                    Colors = new [] { "white" },
                    Price = 57,
                    RemainedQuantity = 1
                },
                new Shoe {
                    ProductName = "Master Running Shoes",
                    Brand = "Nike",
                    ImageUrl = "https://images.unsplash.com/photo-1525966222134-fcfa99b8ae77?ixid=MXwxMjA3fDB8MHxzZWFyY2h8MzB8fHNob2VzJTIwcHVtYXxlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                    Colors = new [] { "brown", "orange", "maroon" },
                    Price = 480.50M,
                    RemainedQuantity = 50
                },
                new Shoe {
                    ProductName = "Air Max 2021 with special gift",
                    Brand = "Puma",
                    ImageUrl = "https://images.unsplash.com/photo-1511556532299-8f662fc26c06?ixid=MXwxMjA3fDB8MHxzZWFyY2h8MzF8fHNob2VzJTIwcHVtYXxlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                    Colors = new [] { "blue", "white" },
                    Price = 323,
                    RemainedQuantity = 13
                }
            };
        }
    }
}
