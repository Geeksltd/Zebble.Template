using System.Threading.Tasks;
using Zebble;

class ActionButton : Button
{
    public Column Container { get; }
    public TextView Primary { get; }
    public TextView Secondary { get; }

    public ActionButton()
    {
        Container = new Column();

        Primary = new TextView
        {
            CssClass = "primary"
        };

        Secondary = new TextView
        {
            CssClass = "secondary muted"
        };
    }

    public override async Task OnInitializing()
    {
        await base.OnInitializing();

        await Container.Add(Primary);
        await Container.Add(Secondary);

        await Add(Container);
    }
}