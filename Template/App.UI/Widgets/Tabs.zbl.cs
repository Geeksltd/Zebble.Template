using System;
using System.Linq;
using System.Threading.Tasks;
using Olive;
using Zebble.Mvvm;

namespace Zebble
{
	partial class Tabs
	{
		internal static Tabs Current = new Tabs().Absolute().Hide();

		internal static void Appear(bool animate = false)
		{
			if (Current.Parent == null) return;
			Current.BringToFront();

			if (animate)
			{
				Current.Animate(Animation.DefaultDuration, AnimationEasing.Linear,
					   x => x.Visible().Opacity(0),
					   x => x.Opacity(1))
					.RunInParallel();
			}
			else UIWorkBatch.RunSync(() => Current.Visible().Opacity(1));
		}

		internal static void Disappear(bool animate = false)
		{
			if (animate)
			{
				var ani = Animation.Create(Current, Animation.DefaultDuration, AnimationEasing.Linear, change: x => x.Opacity(0))
				   .OnCompleted(() =>
				   {
					   Current.Hide();
					   Current.SendToBack();
				   });

				Current.Animate(ani).RunInParallel();
			}
			else
			{
				UIWorkBatch.RunSync(() => Current.Hide().Opacity(0));
				Current.SendToBack();
			}
		}

		internal async Task Attach()
		{
			if (Current.Parent != null) return;

			Current.Y.BindTo(Root.Height, Current.Height, (x, y) => x - y);
			await Current.ApplyStyles();
			await Root.Add(Current.Visible());
			await Current.BringToFront();
		}

		public override async Task OnPreRender()
		{
			await base.OnPreRender();
			HighlightSelectedTab();
			Nav.NavigationAnimationStarted.Handle(HighlightSelectedTab);
		}

		void HighlightSelectedTab()
		{
			foreach (var vm in CurrentNavPath())
			{
				var selected = AllChildren.OfType<Tab>().FirstOrDefault(tab => tab.VM == vm);

				if (selected != null)
				{
					selected.Highlight();
					return;
				}
			}
		}

		Mvvm.ViewModel[] CurrentNavPath() => Mvvm.ViewModel.Stack.Concat(Mvvm.ViewModel.Page).ExceptNull().Reverse().ToArray();
	}
}
