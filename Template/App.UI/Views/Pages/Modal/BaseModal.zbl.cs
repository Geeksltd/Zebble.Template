namespace UI.Pages
{
    using System;
    using System.Threading.Tasks;
    using Olive;
    using Zebble;

    partial class BaseModal
    {
        // public readonly Bindable<string> Title = new Bindable<string>();

        public string Title
        {
            get => ModalTitle.Text;
            set
            {
                Header.Ignored = value.IsEmpty();
                ModalTitle.Text(value);
            }
        }

        public override async Task OnInitializing()
        {
            await base.OnInitializing();

            Height.MinLimit = Root.ActualHeight * 0.7f;

            Margin.Left.BindTo(Width, Root.Width, (x, y) => (y - x) / 2);
            Margin.Top.BindTo(Height, Root.Height, (x, y) => (y - x) / 2);
        }

        protected virtual Task CloseTouched()
        {
            Zebble.Mvvm.ViewModel.HidePopUp();
            return Task.CompletedTask;
        }
    }
}