namespace Zebble
{
    using System;
    using System.Threading.Tasks;
    using Zebble.Mvvm;

    partial class Tab
    {
        public virtual Type Target { get; set; }

        public FullScreen VM => (FullScreen)ViewModel.The(Target);

        public string Text { get => Label.Text; set => Label.Text(value); }

        public string Icon { get => IconView.Path; set => IconView.Path(value); }

        async Task Tap() => ViewModel.Go(VM, PageTransition.None);

        public Task Highlight()
        {
            return UIWorkBatch.Run(async () =>
                        {
                            await SetPseudoCssState("active");
                            foreach (var s in this.AllSiblings<Tab>()) await s.UnsetPseudoCssState("active");
                        });
        }
    }
}