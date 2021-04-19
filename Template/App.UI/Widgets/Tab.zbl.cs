using System;
using System.Linq;
using System.Threading.Tasks;
using Zebble.Mvvm;

namespace Zebble
{
	partial class Tab
	{
		public virtual Type Target { get; set; }

		public FullScreen VM => (FullScreen)Zebble.Mvvm.ViewModel.The(Target);

		public bool IsPrimary;
		public bool IsActive { get => Path == ActiveIcon; set { Path = value ? ActiveIcon : Icon; } }
		public string Icon, ActiveIcon;
		public float GetTopPadding() => Zebble.Device.Screen.SafeAreaInsets.Bottom > 0 ? 7 : 0;
		public float GetBottomPadding() => Zebble.Device.Screen.SafeAreaInsets.Bottom > 0 ? 15 : 0;

		async Task Tap() => Zebble.Mvvm.ViewModel.Go(VM, PageTransition.Fade);

		public override async Task OnPreRender()
		{
			await base.OnPreRender();
			IsActive = IsActive;
		}

		public Task Highlight()
		{
			return UIWorkBatch.Run(async () =>
			{
				IsActive = true;

				foreach (var tab in this.AllSiblings<Tab>().Where(x => x.IsActive))
					tab.IsActive = false;
			});
		}
	}
}
