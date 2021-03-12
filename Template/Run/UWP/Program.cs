namespace UWP
{
    class Program
    {
        public static void Main()
        {
            Zebble.UIRuntime.Initialize<Program>("MyProjectName");
            Windows.UI.Xaml.Application.Start((p) => new App());
        }
    }
}