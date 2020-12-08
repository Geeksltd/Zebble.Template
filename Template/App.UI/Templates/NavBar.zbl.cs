namespace UI.Templates
{
	using System;
	using System.Threading.Tasks;
	using Zebble;

    partial class NavBar
    {
        public string Title { get => Bar.Title.Text; set => Bar.Title.Text(value); }

        public override async Task OnPreRender()
        {
            await base.OnPreRender();

            BodyScrollerWrapper.Y.BindTo(Bar.Height, SafeAreaContainer.Padding.Top, (h, p) => h + p);
            BodyScrollerWrapper.Height.BindTo(SafeAreaContainer.Height, Bar.Height, Tabs.Current.Height, SafeAreaContainer.Padding.Top, (vh, nh, ts, st) => vh - nh - st - ts);
        }
    }
}