using Domain;
using Domain.Models;
using Olive;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebble.Mvvm;
using Zebble;

namespace ViewModel
{
    public class Categories : FullScreen
    {
        public readonly Bindable<Category[]> AllCategories = new(new Category[] { });
        public readonly CollectionViewModel<Item> Items = new();


        protected override async Task NavigationStartedAsync()
        {
            await LoadListItems();
            await base.NavigationStartedAsync();
        }

        public async Task LoadListItems()
        {

            var categories = (await Api.Category.GetCategories()).ToArray();
            AllCategories.Set(categories);
            Items.Replace(categories);
        }

        public class Item : Zebble.Mvvm.ViewModel<Category>
        {
            public Bindable<string> Name => Source.Get(x => x.Name);

            public void OnCategoryTapped() => Forward<CategoryDetails>(x => x.Source(Source));

        }


    }
}
