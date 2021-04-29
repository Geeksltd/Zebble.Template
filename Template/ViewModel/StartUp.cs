namespace ViewModel
{
	using System.Threading.Tasks;
	using Zebble;
	using Zebble.Mvvm;
	using Olive;
    using Domain;

    class StartUp
	{
		public static Task Run()
		{
			// Comment this line out to use the Live API
			Api.Fake();

			ViewModel.Go<LandingPage>(PageTransition.Fade);

			return Task.CompletedTask;
		}
	}
}