using System.Threading.Tasks;
using Zebble;

namespace UI.Templates
{
	partial class NavBar
	{
		public string Title { get => Bar.Title.Text; set => Bar.Title.Text(value); }
		public Stack Footer = new() { Id = "Footer" };

		public override async Task OnPreRender()
		{
			await base.OnPreRender();
			await Main.AddRange(new View[] { Footer });
		}
	}
}