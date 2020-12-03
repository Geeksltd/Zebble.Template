using Zebble;
using Zebble.Device;

class FillParent : Column
{
    public FillParent()
    {
        Css.Height(Root.ActualHeight);
        Css.Padding(top: Screen.SafeAreaInsets.Top);
    }
}