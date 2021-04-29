using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Domain
{
    interface ICategoryApi
    {
        Task<Category[]> GetCategories();

        Task<Category> GetCategory(Guid id);
    }
}
