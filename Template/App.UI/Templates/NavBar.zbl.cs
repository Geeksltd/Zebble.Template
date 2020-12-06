using System.Threading.Tasks;
using Zebble;

namespace UI.Templates
{
    partial class NavBar
    {
        string title;
        public string Title
        {
            get => title;
            set { title = value; Bar?.Title?.Text(value); }
        }

        public override Task OnPreRender() => base.OnPreRender().ContinueWith(x => Title = title);
    }
}