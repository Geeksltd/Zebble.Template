using Zebble;

namespace UI.Templates
{
    partial class NavBar
    {
        public string Title { get => Bar.Title.Text; set => Bar.Title.Text(value); }
    }
}