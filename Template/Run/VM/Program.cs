namespace VM
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        public static async Task Main(string[] args)
        {
            Zebble.Console.Configure();
            await ViewModel.StartUp.Run();
            if (args.None()) Zebble.Console.AwaitNextCommand();
        }
    }
}