namespace UI
{
    using System;
    using System.Threading.Tasks;

    partial class MainMenu
    {
        public MainMenu()
        {
            Model.Actioned += Collapse;
        }
    }
}