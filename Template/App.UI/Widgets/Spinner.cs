using System;
using System.Threading.Tasks;
using Zebble;

class Spinner : Center
{
    public ImageView Image { get; }

    public Spinner()
    {
        Image = new ImageView
        {
            Alignment = Alignment.Middle,
            ZIndex = 1000
        }.Width(100.Percent()).Height(100.Percent());
    }

    public override async Task OnInitializing()
    {
        await base.OnInitializing();

        CssClass += $"parent-center {CssClass}".TrimEnd();

        await Add(Image);
        await WhenShown(RotateForEver);
    }

    async Task RotateForEver()
    {
        await Task.Delay(Animation.OneFrame);

        Image.Animate(new Animation
        {
            Change = () => Image.Rotation(360),
            Repeats = -1,
            Duration = 3.Seconds(),
            Easing = AnimationEasing.Linear
        }).RunInParallel();
    }
}
