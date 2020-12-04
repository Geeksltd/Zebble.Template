namespace ViewModel
{
    using System.Threading.Tasks;
    using Zebble;

    // TODO: Learn: https://zebble.net/docs/introduction
    class StartUp
    {
        public static Task Run()
        {
            Waiting.Indicator = Spinner.WaitingIndicator;

            Zebble.Mvvm.ViewModel.Go<WelcomePage>();
            return Task.CompletedTask;
        }
    }
}
