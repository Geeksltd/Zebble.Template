namespace ViewModel
{
    using System.Threading.Tasks;
    using Zebble;

    // TODO: Learn: https://zebble.net/docs/introduction
    class StartUp
    {
        public static Task Run()
        {
            FirebaseAuth.Current.Initialize(Config.Get("Firebase.ApiToken"));

            // TODO: Any required init
            Zebble.Mvvm.ViewModel.Go<WelcomePage>();
            return Task.CompletedTask;
        }
    }
}