using Zebble;
using Zebble.Device;

class SafeArea : Canvas
{
    public SafeArea()
    {
        Css.Height(Root.ActualHeight);
        Css.Padding(top: Screen.SafeAreaInsets.Top);
    }
}