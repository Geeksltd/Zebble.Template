using Domain;
using Domain.Models;
using Olive;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zebble.Mvvm;

namespace ViewModel
{
    public class CategoryDetails : FullScreen<Category>
    {
        public Bindable<string> Name => Source.Get(x => x.Name);

        protected override async Task NavigationStartedAsync() => await base.NavigationStartedAsync();

    }
}
