namespace Zebble
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Olive;

    partial class NavigationBar
    {
        readonly Bindable<Guid> Visit = new();
        Bindable<bool> CanGoBack => Visit.Get(x => Nav.Stack.Any());

        Task OpenMenu() => MainMenu.Current.Expand();
    }
}