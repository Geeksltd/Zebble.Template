using Domain;
using Domain.Models;
using Olive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebble.Mvvm;

namespace ViewModel
{
    public class Categories : FullScreen
    {
        public readonly Bindable<Category[]> AllCategories = new(new Category[] { });

        protected override async Task NavigationStartedAsync()
        {
            await LoadListItems();
            await base.NavigationStartedAsync();
        }

        public async Task LoadListItems()
        {

            var categories = (await Api.Category.GetCategories()).ToArray();
            AllCategories.Set(categories);
        }

        public class Item : Zebble.Mvvm.ViewModel<Category>
        {
            public Bindable<string> Name => Source.Get(x => x.Name);
        }


    }
}
