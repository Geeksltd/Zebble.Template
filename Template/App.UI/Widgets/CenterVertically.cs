using Zebble;
using Zebble.Device;

class CenterVertically : Column
{
    public CenterVertically()
    {
        Css.Y(new Length.BindingLengthRequest(Height, Root.Height, (vh, rh) => (rh - vh) / 2));
        Css.Padding(top: Screen.SafeAreaInsets.Top);
    }
}