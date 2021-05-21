using Olive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace App.Tests
{
    class CategoriesTest : LoggedInUserAccount
    {
        protected override async Task Execute()
        {
            On<Categories>().Items.First().OnCategoryTapped();
            Expect("Category details");
            NavBarBack();
            Expect("Categories");
            Zebble.Mvvm.ViewModel.The<Tabs>().OnContactsTapped();
            Expect("Contacts");
            On<Contacts>().Items.First().OnContactTapped();
            On<ContactInfo>().OnDeleteContactTapped();
            await On<DeleteContactConfirmation>().OnConfirmTapped();
            On<SuccessAlert>().OnOkTapped();
            Expect("Categories");

        }
    }
}
