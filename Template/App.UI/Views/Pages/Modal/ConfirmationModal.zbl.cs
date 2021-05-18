namespace UI.Pages
{
    using System;
    using System.Threading.Tasks;
    using Zebble;

    partial class ConfirmationModal
    {
        // public readonly Bindable<string> Title = new Bindable<string>();

        public string Message { get => ConfirmationMessage.Text; set => ConfirmationMessage.Text(value); }

        public override async Task OnInitializing()
        {
            await base.OnInitializing();

            X.BindTo(Width, Root.Width, (x, y) => (y - x) / 2);
            ModalPanelWrapper.Y.BindTo(ModalPanelWrapper.Height, Root.Height, (x, y) => (y / 2) - x);
            // Height.MinLimit = Root.ActualHeight * 0.7f;

            // Margin.Left.BindTo(Width, Root.Width, (x, y) => (y - x) / 2);
            // Margin.Top.BindTo(Height, Root.Height, (x, y) => (y - x) / 2);
        }

        public override async Task OnPreRender()
        {
        }
    }
}