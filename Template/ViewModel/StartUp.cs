namespace ViewModel
{
    using System.Threading.Tasks;

    // TODO: Learn: https://zebble.net/docs/introduction
    class StartUp
    {
        public static Task Run()
        {
            // TODO: Any required init
            Zebble.Mvvm.ViewModel.Go<WelcomePage>();
            return Task.CompletedTask;
        }
    }
}