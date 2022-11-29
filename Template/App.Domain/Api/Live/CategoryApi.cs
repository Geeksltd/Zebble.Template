using Domain.Models;
using Olive;
using System;
using System.Threading.Tasks;
using Zebble;

namespace Domain
{
    public class CategoryApi : BaseApi, ICategoryApi
    {
        private string baseApi = "https://test.co/api/v1/coffee-drinks";

        public Task<Category[]> GetCategories() => Get<Category[]>(baseApi).OrEmpty().ToArray();
        public Task<Category> GetCategory(Guid id) => Get<Category>($"{baseApi}/{id}").OrCompleted();
    }
}
